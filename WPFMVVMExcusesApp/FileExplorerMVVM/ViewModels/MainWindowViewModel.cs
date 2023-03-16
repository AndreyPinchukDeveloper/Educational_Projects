using FileExplorerMVVM.Infrastructure.Commands;
using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels.Base;
using Microsoft.VisualBasic.FileIO;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FileExplorerMVVM.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        #region Properties
        private readonly FileDetailsModel _fileDetailsModel;

        readonly ResourceDictionary _iconDictionary = Application.LoadComponent(
            new Uri("/FileExplorerMVVM;component/Views/Resources/Styles/Icons.xaml", 
                UriKind.RelativeOrAbsolute)) as ResourceDictionary;

        public string ParentDirectory { get; set; }
        public string PreviousDirectory { get; set; }

        private string _currentDirectory;
        public string CurrentDirectory
        {
            get => _currentDirectory;
            set => Set(ref _currentDirectory, value);
        }
        public string NextDirectory { get; set; }
        public string SelectedDriveSize { get; set; }
        
        private  string _selectedFolderDetails;
        public string SelectedFolderDetails
        {
            get => _selectedFolderDetails;
            set => Set(ref _selectedFolderDetails, value);
        }

        public ObservableCollection<FileDetailsModel> FavoriteFolders { get; set; }
        public ObservableCollection<FileDetailsModel> RemoteFolders { get; set; }
        public ObservableCollection<FileDetailsModel> LibraryFolders { get; set; }
        public ObservableCollection<FileDetailsModel> ConnectedDevices { get; set; }

        private ObservableCollection<FileDetailsModel> _navigatedFolderFiles;
        public ObservableCollection<FileDetailsModel> NavigatedFolderFiles 
        { 
            get => _navigatedFolderFiles;
            set => Set(ref _navigatedFolderFiles, value);
        }

        public ObservableCollection<SubMenuItemDetails> HomeTabSubMenuCollection { get; set; }
        public ObservableCollection<SubMenuItemDetails> ViewTabSubMenuCollection { get; set; }

        #region Back-Forward buttons filds

        private ObservableCollection<string> _pathHistoryCollection;
        public ObservableCollection<string> PathHistoryCollection
        {
            get => _pathHistoryCollection;
            set => Set(ref _pathHistoryCollection, value);
        }

        internal int position = 0;

        private bool _canGoBack;
        public bool CanGoBack
        {
            get => _canGoBack;
            set => Set(ref _canGoBack, value);
        }
        
        private bool _canGoForward;
        public bool CanGoForward
        {
            get => _canGoForward;
            set => Set(ref _canGoForward, value);
        }
        private bool _isAtRootDirectory;
        public bool IsAtRootDirectory
        {
            get => _isAtRootDirectory;
            set => Set(ref _isAtRootDirectory, value);
        }

        private bool _pathDisrupted;
        public bool PathDisrupted
        {
            get => _pathDisrupted;
            set
            {
                Set(ref _pathDisrupted, value);
                if (_pathDisrupted)
                {
                    var tempCollection = new ObservableCollection<string>();
                    for (int i = position; i < PathHistoryCollection.Count - 1; i++)
                    {
                        tempCollection.Add(PathHistoryCollection[i]);
                    }

                    foreach (var path in tempCollection)
                    {
                        PathHistoryCollection.Remove(path);
                    }
                    _pathDisrupted = false;
                }
            }
        }
        #endregion


        internal ReadOnlyCollection<string> tempFolderCollection;
        
        public BackgroundWorker bgGetFiles = new BackgroundWorker()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        public BackgroundWorker bgGetFilesSize = new BackgroundWorker()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };
        #endregion

        public void LoadDirectory(FileDetailsModel fileDetailsModel)
        {
            CanGoBack = position != 0;
            NavigatedFolderFiles.Clear();
            tempFolderCollection = null;

            if (PathHistoryCollection != null && position>0)
            {
                if (PathHistoryCollection.ElementAt(position) != fileDetailsModel.Path)
                {
                    PathDisrupted = true;
                }
            }
            if (bgGetFiles.IsBusy) bgGetFiles.CancelAsync();

            bgGetFiles.RunWorkerAsync(fileDetailsModel);
        }

        internal string GetFilesExtension(string fileName)
        {
            if(fileName== null) return string.Empty;
            var extension = Path.GetExtension(fileName);
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;
            var data = textInfo.ToTitleCase(extension.Replace(".",string.Empty));
            var attribute = FileAttributes.Normal;
            return data;
        }

        internal static readonly List<string> ImageExtensions = new List<string>()
        {
            ".jpg",
            ".jpeg",
            ".bmp",
            ".gif",
            ".png"
        };

        internal static readonly List<string> VideoExtensions = new List<string>()
        {
            ".mp4",
            ".m4v",
            ".mov",
            ".wmv",
            ".avi",
            ".avchd",
            ".flv",
            ".f4v",
            ".swf",
            ".mkv",
            ".webm"
        };

        internal PathGeometry GetImageForExtension(FileDetailsModel file)
        {
            var fileExtension = file.FileExtension;
            if(Directory.Exists(file.Path)) 
                return (PathGeometry)_iconDictionary["Folder"];

            if (file.IsImage)
                return (PathGeometry)_iconDictionary["ImageFile"];

            if (file.IsVideo)
                return (PathGeometry)_iconDictionary["VideoFile"];

            if ((PathGeometry)_iconDictionary[$"{fileExtension}File"] == null)
                return (PathGeometry)_iconDictionary["File"];

            return (PathGeometry)_iconDictionary[$"{fileExtension}File"];
        }

        public MainWindowViewModel()
        {
            _fileDetailsModel = new FileDetailsModel();

            RemoteFolders = new ObservableCollection<FileDetailsModel>()
            {
                new FileDetailsModel()
                {
                    Name = "OneDrive",
                    IsDirectory = true,
                    Path = Environment.GetEnvironmentVariable("OneDriveConsumer"),
                    FileIcon = (PathGeometry)_iconDictionary["OneDrive"]
                },
                new FileDetailsModel()
                {
                    Name = "Google Drive",
                    IsDirectory = true,
                    Path = "",
                    FileIcon = (PathGeometry)_iconDictionary["GoogleDrive"]
                },
                new FileDetailsModel()
                {
                    Name = "DropBox",
                    IsDirectory = true,
                    Path = "",
                    FileIcon = (PathGeometry)_iconDictionary["Dropbox"]
                }
            };

            LibraryFolders = new ObservableCollection<FileDetailsModel>()
            {
                new FileDetailsModel()
                {
                    Name = "Desktop",
                    IsDirectory = true,
                    Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    FileIcon = (PathGeometry)_iconDictionary["DesktopFolder"]
                },
                new FileDetailsModel()
                {
                    Name = "Documents",
                    IsDirectory = true,
                    Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    FileIcon = (PathGeometry)_iconDictionary["DocumentsFolder"]
                },
                new FileDetailsModel()
                {
                    Name = "Downloads",
                    IsDirectory = true,
                    Path = new KnownFolder(KnownFolderType.Downloads).Path,
                    FileIcon = (PathGeometry)_iconDictionary["DownloadsFolder"]
                },
                new FileDetailsModel()
                {
                    Name = "Pictures",
                    IsDirectory = true,
                    Path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    FileIcon = (PathGeometry)_iconDictionary["PicturesFolder"]
                },
                new FileDetailsModel()
                {
                    Name = "Videos",
                    IsDirectory = true,
                    Path = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                    FileIcon = (PathGeometry)_iconDictionary["VideosFolder"]
                },
                new FileDetailsModel()
                {
                    Name = "Music",
                    IsDirectory = true,
                    Path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                    FileIcon = (PathGeometry)_iconDictionary["MusicsFolder"]
                },
            };

            ConnectedDevices = new ObservableCollection<FileDetailsModel>();
            //represent all disks on your PC
            foreach (var drive in DriveInfo.GetDrives())
            {
                var name = string.IsNullOrEmpty(drive.VolumeLabel) ? "Local Disk" : drive.VolumeLabel;
                ConnectedDevices.Add(new FileDetailsModel()
                {
                    Name = $"{name}({drive.Name.Replace(@"\", "")})",
                    Path = drive.RootDirectory.FullName,
                    IsDirectory = true,
                    FileIcon = drive.Name.Contains("C:")
                        ?(PathGeometry) _iconDictionary["CDrive"]
                        :(PathGeometry)_iconDictionary["NormalDrive"]
                }); 
            }

            LoadSubMenuCollectionCommand = new LoadSubMenuCollectionCommand(this);
            LoadSubMenuCollectionCommand.Execute(null);
            
            CurrentDirectory = @"C:\";

            NavigatedFolderFiles = new ObservableCollection<FileDetailsModel>();
            bgGetFiles.DoWork += BgGetFiles_DoWork;
            bgGetFiles.ProgressChanged += BgGetFiles_ProgressChanged;
            bgGetFiles.RunWorkerCompleted += BgGetFiles_RunWorkerCompleted;

            LoadDirectory(new FileDetailsModel()
            {
                Path = CurrentDirectory
            });

            PathHistoryCollection = new ObservableCollection<string>();
            PathHistoryCollection.Add(CurrentDirectory);

            CanGoBack = position != 0;
            GetFilesListCommand = new GetFilesListCommand(this);
            GetFilesSizeCommand = new GetFilesSizeCommand(this, bgGetFiles, bgGetFilesSize, NavigatedFolderFiles);
            OpenSettingsCommand = new OpenSettingsCommand();
        }

        public static MainWindowViewModel LoadViewModel()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            return viewModel;
        }

        private void BgGetFiles_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void BgGetFiles_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            var fileName = e.UserState.ToString();
            var file = new FileDetailsModel();
            file.Name = Path.GetFileName(fileName);
            file.Path = fileName;
            file.IsHidden = _fileDetailsModel.IsFileHidden(fileName);
            file.IsReadonly = _fileDetailsModel.IsFileReadOnly(fileName);
            file.IsDirectory = _fileDetailsModel.IsDirectoryMethod(fileName);
            file.FileExtension = GetFilesExtension(fileName);
            file.IsImage = ImageExtensions.Contains(file.FileExtension.ToLower());
            file.IsVideo = VideoExtensions.Contains(file.FileExtension.ToLower());
            file.FileIcon = GetImageForExtension(file);

            NavigatedFolderFiles.Add(file);
        }

        private void BgGetFiles_DoWork(object? sender, DoWorkEventArgs e)
        {
            var fileOrFolder = (FileDetailsModel)e.Argument;
            tempFolderCollection = new ReadOnlyCollectionBuilder<string>(FileSystem.GetDirectories(fileOrFolder.Path).Concat(FileSystem.GetFiles(fileOrFolder.Path))).ToReadOnlyCollection();

            foreach (var file in tempFolderCollection) 
            {
                bgGetFiles.ReportProgress(1, file);
            }

            CurrentDirectory = fileOrFolder.Path;

            var root = Path.GetPathRoot(fileOrFolder.Path);
            if (string.IsNullOrWhiteSpace(CurrentDirectory) || CurrentDirectory==root)
            {
                IsAtRootDirectory = true;
            }
            else { IsAtRootDirectory = false; }
        }

        #region Commands
        public ICommand OpenSettingsCommand { get; set; }
        public ICommand LoadSubMenuCollectionCommand { get; set; }
        public ICommand GetFilesListCommand { get; set; }
        public ICommand GetFilesSizeCommand { get; set; }

        protected ICommand _goToPreviousDirectoryCommand;
        public ICommand GoToPreviousDirectoryCommand => _goToPreviousDirectoryCommand ??
            (_goToPreviousDirectoryCommand = new OpenWindowsSettingsCommand(() =>
            {
                if (position>=1)
                {
                    position--;
                    LoadDirectory(new FileDetailsModel()
                    {
                        Path = PathHistoryCollection.ElementAt(position)
                    });

                    CanGoForward = true;
                    PathDisrupted = false;
                }                
            }));

        protected ICommand _goToForwardDirectoryCommand;
        public ICommand GoToForwardDirectoryCommand => _goToForwardDirectoryCommand ??
            (_goToForwardDirectoryCommand = new OpenWindowsSettingsCommand(() =>
            {
                if (position < PathHistoryCollection.Count -1)
                {
                    position++;
                    LoadDirectory(new FileDetailsModel()
                    {
                        Path = PathHistoryCollection.ElementAt(position)
                    });

                    CanGoForward = 
                        position < PathHistoryCollection.Count - 1 &&
                        position != PathHistoryCollection.Count - 1;
                }
            }));

        protected ICommand _goToParentDirectoryCommand;
        public ICommand GoToParentDirectoryCommand => _goToParentDirectoryCommand ??
            (_goToParentDirectoryCommand = new OpenWindowsSettingsCommand(() =>
            {
                var ParentDirectory = string.Empty;
                PathDisrupted = true;
                var d = new DirectoryInfo(ParentDirectory);

                if (d.Parent != null)
                {
                    ParentDirectory = d.Parent.FullName;
                    IsAtRootDirectory = false;
                }
                else if (d.Parent == null)
                {
                    IsAtRootDirectory = true;
                    return;
                }
                else
                {
                    ParentDirectory= d.Root.ToString()
                    .Split(Path.DirectorySeparatorChar)[1];
                }

                GetFilesListCommand.Execute(new FileDetailsModel()
                {
                    Path = ParentDirectory
                });
            }));
        #endregion
    }
}

﻿using FileExplorerMVVM.Infrastructure.Commands;
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
    class MainWindowViewModel:ViewModelBase
    {
        #region Properties
        private readonly FileDetailsModel _fileDetailsModel;

        readonly ResourceDictionary _iconDictionary = Application.LoadComponent(
            new Uri("/FileExplorerMVVM;component/Views/Resources/Styles/Icons.xaml", 
                UriKind.RelativeOrAbsolute)) as ResourceDictionary;

        public string ParentDirectory { get; set; }
        public string PreviousDirectory { get; set; }
        public string CurrentDirectory { get; set; }
        public string NextDirectory { get; set; }
        public string SelectedDriveSize { get; set; }
        public string SelectedFolderDetails { get; set; }

        public ObservableCollection<FileDetailsModel> FavoriteFolders { get; set; }
        public ObservableCollection<FileDetailsModel> RemoteFolders { get; set; }
        public ObservableCollection<FileDetailsModel> LibraryFolders { get; set; }
        public ObservableCollection<FileDetailsModel> ConnectedDevices { get; set; }
        public ObservableCollection<FileDetailsModel> NavigatedFolderFiles { get; set; }
        public ObservableCollection<SubMenuItemDetails> HomeTabSubMenuCollection { get; set; }
        public ObservableCollection<SubMenuItemDetails> ViewTabSubMenuCollection { get; set; }
        
        internal ReadOnlyCollection<string> tempFolderCollection;
        
        BackgroundWorker bgGetFiles = new BackgroundWorker()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };
        #endregion

        void LoadDirectory(FileDetailsModel fileDetailsModel)
        {
            NavigatedFolderFiles.Clear();
            tempFolderCollection = null;

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

            //LoadSubMenuCollectionCommand = new LoadSubMenuCollectionCommand();
            //LoadSubMenuCollectionCommand.Execute(null);
            //LoadSubMenuCollectionCommand.Execute(null);//do we really need that ?
            
            CurrentDirectory = @"C:\";

            OnPropertyChanged(nameof(CurrentDirectory));

            NavigatedFolderFiles = new ObservableCollection<FileDetailsModel>();
            bgGetFiles.DoWork += BgGetFiles_DoWork;
            bgGetFiles.ProgressChanged += BgGetFiles_ProgressChanged;
            bgGetFiles.RunWorkerCompleted += BgGetFiles_RunWorkerCompleted;

            LoadDirectory(new FileDetailsModel()
            {
                Path = CurrentDirectory
            });
        }

        //public ICommand LoadSubMenuCollectionCommand { get;}

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
            OnPropertyChanged(nameof(NavigatedFolderFiles));
        }

        private void BgGetFiles_DoWork(object? sender, DoWorkEventArgs e)
        {
            var fileOrFolder = (FileDetailsModel)e.Argument;
            tempFolderCollection = new ReadOnlyCollectionBuilder<string>(FileSystem.GetDirectories(fileOrFolder.Path).Concat(FileSystem.GetFiles(fileOrFolder.Path))).ToReadOnlyCollection();

            foreach (var file in tempFolderCollection) 
            {
                bgGetFiles.ReportProgress(1,file);
            }

            CurrentDirectory = fileOrFolder.Path;
            OnPropertyChanged(nameof(CurrentDirectory));
        }

        #region Commands

        private ICommand _openSettingsCommand;
        public ICommand openSettingsCommand
        {
            get { return _openSettingsCommand ?? (_openSettingsCommand = new OpenWindowsSettingsCommand(() => Process.Start(new ProcessStartInfo { FileName = "ms-settings:home", UseShellExecute = true }))); }
        }

        private ICommand _openUserProfileSettingsCommand;
        public ICommand openUserProfileSettingsCommand
        {
            get { return _openUserProfileSettingsCommand ?? (_openUserProfileSettingsCommand = new OpenWindowsSettingsCommand(() => Process.Start(new ProcessStartInfo { FileName = "ms-settings:home", UseShellExecute = true }))); }
        }

        /*private ICommand _loadSubMenuCollectionCommand;
        public ICommand LoadSubMenuCollectionCommand
        {
            get 
            {
                return _loadSubMenuCollectionCommand ??
                    (_loadSubMenuCollectionCommand = new OpenWindowsSettingsCommand(()=>
                    {
                        HomeTabSubMenuCollection = new ObservableCollection<SubMenuItemDetails>
                        {
                            new SubMenuItemDetails()
                            {
                                Name= "Pin",
                                Icon = (PathGeometry)_iconDictionary["Pin"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Copy",
                                Icon = (PathGeometry)_iconDictionary["Copy"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Cut",
                                Icon = (PathGeometry)_iconDictionary["Cut"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Paste",
                                Icon = (PathGeometry)_iconDictionary["Paste"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Delete",
                                Icon = (PathGeometry)_iconDictionary["Delete"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Rename",
                                Icon = (PathGeometry)_iconDictionary["Rename"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "New Folder",
                                Icon = (PathGeometry)_iconDictionary["NewFolder"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Properties",
                                Icon = (PathGeometry)_iconDictionary["FileSettings"]
                            }
                        };

                        ViewTabSubMenuCollection = new ObservableCollection<SubMenuItemDetails>
                        {
                            new SubMenuItemDetails()
                            {
                                Name= "List",
                                Icon = (PathGeometry)_iconDictionary["ListView"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Tile",
                                Icon = (PathGeometry)_iconDictionary["TileView"]
                            }
                        };
                    }));
            }
        }*/

        protected ICommand _getFilesListCommand;

        public ICommand GetFilesListCommand =>
            _getFilesListCommand ?? (_getFilesListCommand = new RelayCommand(parameter =>
            {
                var file = parameter as FileDetailsModel;
                if (file == null) return;

                LoadDirectory(file);
            }));
        #endregion
    }
}

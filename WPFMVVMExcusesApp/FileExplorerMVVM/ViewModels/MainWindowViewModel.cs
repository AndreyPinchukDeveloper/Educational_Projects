using FileExplorerMVVM.Infrastructure.Commands;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FileExplorerMVVM.ViewModels
{
    class MainWindowViewModel:ViewModelBase
    {
        #region Properties

        readonly ResourceDictionary _iconDictionary = Application.LoadComponent(
            new Uri("/FileExplorerRedesign;component/Resources/Icons.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;

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

        #endregion

        ICommand ButtonBaseCommand { get; set; }

        public MainWindowViewModel()
        {
            ButtonBaseCommand = new ButtonBaseCommand();


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
                    FileIcon = (PathGeometry)_iconDictionary["DropBox"]
                }
            };
        }

    }
}

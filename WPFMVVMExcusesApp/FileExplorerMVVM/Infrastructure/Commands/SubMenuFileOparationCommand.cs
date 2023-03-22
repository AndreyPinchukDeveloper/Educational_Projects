using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class SubMenuFileOparationCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public SubMenuFileOparationCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            var subMenuItem = parameter as SubMenuItemDetails;
            if (subMenuItem == null) return;
            try
            {
                switch (subMenuItem.Name)
                {
                    case "Pin":
                        PinFolder();
                        break;
                    case "Copy":
                        Copy();
                        break;
                    case "Cut":
                        Cut();
                        break;
                    case "Paste":
                        Paste(_mainWindowViewModel.IsMoveOperation);
                        break;
                    case "Delete":
                        Delete();
                        break;
                    case "Rename":
                        break;
                    case "New Folder":
                        break;
                    case "Properties":
                        break;
                    case "List":
                        break;
                    case "Tile":
                        break;
                    default:
                        return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Delete()
        {
            var selectedFiles = _mainWindowViewModel.NavigatedFolderFiles.Where(file => file.IsSelected);
            if (selectedFiles.Count() >= 1)
            {
                if (MessageBoxResult.Yes == MessageBox.Show(
                    $"Are you sure you want to move {selectedFiles.Count()} items to the trash ?", 
                    "Delete Multiple Items", 
                    MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No))
                {
                    foreach (var file in selectedFiles) 
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(Path.GetExtension(file.Path)))
                            {
                                FileSystem.DeleteDirectory(file.Path ?? string.Empty, UIOption.OnlyErrorDialogs,
                                    RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
                            }
                            else
                            {
                                FileSystem.DeleteFile(file.Path, UIOption.OnlyErrorDialogs,
                                    RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(selectedFiles.ElementAt(0).Path))
                    {
                        FileSystem.DeleteDirectory(selectedFiles.ElementAt(0).Path, UIOption.OnlyErrorDialogs,
                            RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
                    }
                    else
                    {
                        FileSystem.DeleteFile(selectedFiles.ElementAt(0).Path, UIOption.OnlyErrorDialogs,
                            RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
                    }
                }

                _mainWindowViewModel.LoadDirectory(new FileDetailsModel() { Path = _mainWindowViewModel.CurrentDirectory});
            }
        }

        private void Paste(bool isMoveOperation)
        {
            var destinationPath = _mainWindowViewModel.CurrentDirectory;
            if (!isMoveOperation)
            {
                foreach (var file in _mainWindowViewModel.ClipBoardCollection) 
                {
                    var sourcePath = file.Path;
                    var destinyPath = _mainWindowViewModel.CurrentDirectory + "\\" + file.Name;
                    destinyPath = Path.Combine(sourcePath, destinyPath);
                    var temp = Path.GetExtension(file.Path);

                    if (string.IsNullOrWhiteSpace(temp))
                        FileSystem.CopyDirectory(file.Path, destinyPath, UIOption.AllDialogs, UICancelOption.DoNothing);
                    else
                        FileSystem.CopyFile(file.Path, destinyPath, UIOption.AllDialogs, UICancelOption.DoNothing);
                }
            }
            else
            {
                foreach (var file in _mainWindowViewModel.ClipBoardCollection)
                {
                    var sourcePath = file.Path;
                    var destinyPath = _mainWindowViewModel.CurrentDirectory + "\\" + file.Name;
                    destinyPath = Path.Combine(sourcePath, destinyPath);
                    var temp = Path.GetExtension(file.Path);

                    if (string.IsNullOrWhiteSpace(temp))
                        FileSystem.MoveDirectory(file.Path, destinyPath, UIOption.AllDialogs, UICancelOption.DoNothing);
                    else
                        FileSystem.MoveFile(file.Path, destinyPath, UIOption.AllDialogs, UICancelOption.DoNothing);
                }
            }
            _mainWindowViewModel.LoadDirectory(new FileDetailsModel()
            {
                Path = destinationPath
            });
            isMoveOperation = false;
        }

        private void Cut()
        {
            if (_mainWindowViewModel.ClipBoardCollection == null)
                _mainWindowViewModel.ClipBoardCollection = new ObservableCollection<FileDetailsModel>();
            _mainWindowViewModel.ClipBoardCollection.Clear();

            var selectedFiles = _mainWindowViewModel.NavigatedFolderFiles.Where(file => file.IsSelected);

            foreach (var file in selectedFiles)
            {
                if (!_mainWindowViewModel.ClipBoardCollection.Contains(file))
                    _mainWindowViewModel.ClipBoardCollection.Add(file);
            }
            _mainWindowViewModel.IsMoveOperation = true;
        }

        private void Copy()
        {
            if (_mainWindowViewModel.ClipBoardCollection == null)
                _mainWindowViewModel.ClipBoardCollection = new ObservableCollection<FileDetailsModel>();
            _mainWindowViewModel.ClipBoardCollection.Clear();

            var selectedFiles = _mainWindowViewModel.NavigatedFolderFiles.Where(file => file.IsSelected);
            
            foreach ( var file in selectedFiles) 
            { 
                if(!_mainWindowViewModel.ClipBoardCollection.Contains(file))
                    _mainWindowViewModel.ClipBoardCollection.Add(file);
            }
            _mainWindowViewModel.IsMoveOperation = false;
        }

        private void PinFolder()
        {
            if (_mainWindowViewModel.FavoriteFolders == null) 
                _mainWindowViewModel.FavoriteFolders = new ObservableCollection<FileDetailsModel>();

            try
            {
                var selectedFile = _mainWindowViewModel.NavigatedFolderFiles.Where(folder => folder.IsSelected && !folder.IsPinned && folder.IsDirectory);

                foreach (var directory in selectedFile) 
                {
                    directory.IsPinned = true;
                    _mainWindowViewModel.FavoriteFolders.Add(directory);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

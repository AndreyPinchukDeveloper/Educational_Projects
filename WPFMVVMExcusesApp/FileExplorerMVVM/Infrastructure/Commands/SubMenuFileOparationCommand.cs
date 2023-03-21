﻿using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        break;
                    case "Paste":
                        break;
                    case "Delete":
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

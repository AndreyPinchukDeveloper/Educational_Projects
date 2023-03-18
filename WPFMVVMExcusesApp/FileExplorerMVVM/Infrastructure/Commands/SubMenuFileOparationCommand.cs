using FileExplorerMVVM.Infrastructure.Commands.Base;
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

        private void PinFolder()
        {
            if (_mainWindowViewModel.FavoriteFolders == null)
            {
                _mainWindowViewModel.FavoriteFolders = new ObservableCollection<FileDetailsModel>();
            }
        }
    }
}

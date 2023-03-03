using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Infrastructure.Stores;
using FileExplorerMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class LoadSubMenuCollectionCommand : BaseCommand
    {
        ObservableCollection<SubMenuItemDetails> _homeTabSubMenuCollection;
        private readonly Action _action;
        private readonly ResourceStore _resourceStore;
        public LoadSubMenuCollectionCommand(Action action, ObservableCollection<SubMenuItemDetails> homeTabSubMenuCollection, ResourceStore resourceStore)
        {
            _homeTabSubMenuCollection = homeTabSubMenuCollection;
            _action = action;
            _resourceStore = resourceStore;
        }

        private void Load()
        {
            _homeTabSubMenuCollection = new ObservableCollection<SubMenuItemDetails>
            {
                new SubMenuItemDetails()
                            {
                                Name= "Pin",
                                Icon = (PathGeometry)_resourceStore._iconDictionary["Pin"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Copy",
                                Icon = (PathGeometry)_resourceStore._iconDictionary["Copy"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Cut",
                                Icon = (PathGeometry)_resourceStore._iconDictionary["Cut"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Paste",
                                Icon = (PathGeometry)_resourceStore._iconDictionary["Paste"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Delete",
                                Icon = (PathGeometry)_resourceStore._iconDictionary["Delete"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Rename",
                                Icon = (PathGeometry)_resourceStore._iconDictionary["Rename"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "New Folder",
                                Icon = (PathGeometry)_resourceStore._iconDictionary["NewFolder"]
                            },
                            new SubMenuItemDetails()
                            {
                                Name= "Properties",
                                Icon = (PathGeometry)_resourceStore._iconDictionary["FileSettings"]
                            }
            };
        }


        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}

using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Infrastructure.Stores;
using FileExplorerMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class LoadSubMenuCollectionCommand : BaseCommand
    {
        private ObservableCollection<SubMenuItemDetails> _homeTabSubMenuCollection { get; set; }
        private ObservableCollection<SubMenuItemDetails> _viewTabSubMenuCollection { get; set; }

        public ResourceDictionary _iconDictionary = Application.LoadComponent(
            new Uri("/FileExplorerMVVM;component/Views/Resources/Styles/Icons.xaml",
                UriKind.RelativeOrAbsolute)) as ResourceDictionary;

        /*public LoadSubMenuCollectionCommand(ObservableCollection<SubMenuItemDetails> HomeTabSubMenuCollection, ObservableCollection<SubMenuItemDetails> ViewTabSubMenuCollection)
        {
            _homeTabSubMenuCollection= HomeTabSubMenuCollection;
            _viewTabSubMenuCollection= ViewTabSubMenuCollection;
        }*/

        public override void Execute(object? parameter)
        {
            _homeTabSubMenuCollection = new ObservableCollection<SubMenuItemDetails>
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

            _viewTabSubMenuCollection = new ObservableCollection<SubMenuItemDetails>
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

        }
    }
}

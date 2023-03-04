using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorerMVVM.Infrastructure.Stores
{
    public class ResourceStore
    {
        public ResourceDictionary _iconDictionary = Application.LoadComponent(
            new Uri("/FileExplorerMVVM;component/Views/Resources/Styles/Icons.xaml",
                UriKind.RelativeOrAbsolute)) as ResourceDictionary;
    }
}

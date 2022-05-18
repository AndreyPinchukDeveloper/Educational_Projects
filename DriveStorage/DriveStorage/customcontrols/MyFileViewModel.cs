using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DriveStorage.customcontrols
{
    class MyFileViewModel
    {
        //Resource dictionary
        ResourceDictionary dict = Application.LoadComponent(new Uri
            ("DriveStorage;component/icons.xaml", UriKind.RelativeOrAbsolute)) 
            as ResourceDictionary;

        //public ObservableCollection
    }

    class GetFileDetails
    {
        public PathGeometry FileThumb { get; set; }
        public string Fill { get; set; }
    }
}

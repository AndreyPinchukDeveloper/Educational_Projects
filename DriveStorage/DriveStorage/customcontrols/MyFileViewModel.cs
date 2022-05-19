using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ("DriveStorage;component/resources/icons.xaml", UriKind.RelativeOrAbsolute)) 
            as ResourceDictionary;

        public ObservableCollection<GetFileDetails> getFileDetails
        {
            get 
            {
                return new ObservableCollection<GetFileDetails>
                {
                    new GetFileDetails() { FileThumb=(PathGeometry)dict["Pdf"], FileName="File 1", Fill="Red", FileProgram = "Adobe Acrobat", ModifiedOn="19.05.2022"
                }};
            }
               
        }
    }

    class GetFileDetails
    {
        public PathGeometry FileThumb { get; set; }
        public string Fill { get; set; }
        public string FileName { get; set; }
        public string ModifiedOn { get; set; }
        public string FileType { get; set; }
        public string FileProgram { get; set; }
    }
}

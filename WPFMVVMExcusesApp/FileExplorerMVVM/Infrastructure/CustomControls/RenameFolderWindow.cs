using FileExplorerMVVM.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorerMVVM.Infrastructure.CustomControls
{
    public class RenameFolderWindow:Window
    {
        public string OldFolderName
        {
            get { return (string)GetValue(OldFolderNameProperty); }
            set { SetValue(OldFolderNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OldFolderNameProperty =
            DependencyProperty.Register("OldFolderName", typeof(string), typeof(RenameDialog));

    }
}

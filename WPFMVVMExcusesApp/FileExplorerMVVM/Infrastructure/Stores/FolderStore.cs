using FileExplorerMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Infrastructure.Stores
{
    public class FolderStore
    {
        public ObservableCollection<FileDetailsModel> NavigatedFolderFiles { get; set; }
        public FolderStore()
        {
            NavigatedFolderFiles = new ObservableCollection<FileDetailsModel>();
        }
    }
}

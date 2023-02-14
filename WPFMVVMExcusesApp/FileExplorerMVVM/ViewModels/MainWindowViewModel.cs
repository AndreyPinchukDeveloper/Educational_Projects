using FileExplorerMVVM.Infrastructure.Commands;
using FileExplorerMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileExplorerMVVM.ViewModels
{
    class MainWindowViewModel:ViewModelBase
    {
        ICommand ButtonBaseCommand { get; set; }


        public MainWindowViewModel()
        {
            ButtonBaseCommand = new ButtonBaseCommand();
        }
    }
}

using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class GoToPreviousDirectoryCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public GoToPreviousDirectoryCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_mainWindowViewModel.position >= 1)
            {
                _mainWindowViewModel.position--;
                _mainWindowViewModel.LoadDirectory(new FileDetailsModel()
                {
                    Path = _mainWindowViewModel.PathHistoryCollection.ElementAt(_mainWindowViewModel.position)
                });
            }
        }
    }
}

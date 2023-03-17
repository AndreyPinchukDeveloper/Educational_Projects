using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class GoToParentDirectoryCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public GoToParentDirectoryCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            var ParentDirectory = string.Empty;
            _mainWindowViewModel.PathDisrupted = true;
            var d = new DirectoryInfo(ParentDirectory);

            if (d.Parent != null)
            {
                ParentDirectory = d.Parent.FullName;
                _mainWindowViewModel.IsAtRootDirectory = false;
            }
            else if (d.Parent == null)
            {
                _mainWindowViewModel.IsAtRootDirectory = true;
                return;
            }
            else
            {
                ParentDirectory = d.Root.ToString()
                .Split(Path.DirectorySeparatorChar)[1];
            }

            _mainWindowViewModel.GetFilesListCommand.Execute(new FileDetailsModel()
            {
                Path = ParentDirectory
            });
        }
    }
}

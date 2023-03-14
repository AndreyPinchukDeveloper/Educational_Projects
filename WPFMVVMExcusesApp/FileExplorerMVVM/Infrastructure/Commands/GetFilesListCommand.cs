using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class GetFilesListCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public GetFilesListCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            var file = parameter as FileDetailsModel;
            if (file == null) return;

            _mainWindowViewModel.SelectedFolderDetails = string.Empty;
            if (Directory.Exists(file.Path))
            {
                UpdatePathHistory(file.Path);
                _mainWindowViewModel.LoadDirectory(file);
            }
            else
            {
                try
                {
                    Process.Start(new ProcessStartInfo(file.Path));
                }
                catch (Win32Exception exception)
                {

                    MessageBox.Show(exception.Message, exception.Source);
                }
                catch (InvalidOperationException exception)
                {

                    MessageBox.Show($"{file.Name} isn't installed on this system.", exception.Source);
                }
            }
        }

        private void UpdatePathHistory(string path)
        {
            if (_mainWindowViewModel.PathHistoryCollection != null && string.IsNullOrEmpty(path))
            {
                _mainWindowViewModel.PathHistoryCollection.Add(path);
                _mainWindowViewModel.position++;
            }
        }
    }
}

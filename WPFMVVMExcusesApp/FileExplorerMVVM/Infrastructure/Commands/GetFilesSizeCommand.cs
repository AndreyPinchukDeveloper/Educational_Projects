using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class GetFilesSizeCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly ObservableCollection<FileDetailsModel> _navigatedFolderFiles;       
        private readonly BackgroundWorker _bgGetFilesSize;
        private BackgroundWorker _bgGetFiles { get; set; }

        public GetFilesSizeCommand(MainWindowViewModel mainWindowViewModel, BackgroundWorker bgGetFiles, BackgroundWorker bgGetFilesSize, ObservableCollection<FileDetailsModel> NavigatedFolderFiles)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _bgGetFiles = bgGetFiles;
            _bgGetFilesSize = bgGetFilesSize;
            _navigatedFolderFiles = NavigatedFolderFiles;

            NavigatedFolderFiles = new ObservableCollection<FileDetailsModel>();
        }

        public override void Execute(object? parameter)
        {
            var file = parameter as FileDetailsModel;
            if (file == null) return;
            _mainWindowViewModel.SelectedFolderDetails = "Calculating size...";

            _bgGetFilesSize.DoWork -= BgGetFilesSize_DoWork;
            _bgGetFilesSize.DoWork += BgGetFilesSize_DoWork;

            if (_bgGetFilesSize.IsBusy) _bgGetFilesSize.CancelAsync();
            if (_bgGetFilesSize.CancellationPending)
            {
                _bgGetFiles.Dispose();
                _bgGetFiles = new BackgroundWorker()
                {
                    WorkerSupportsCancellation = true
                };
            }

            _bgGetFilesSize.RunWorkerAsync();
        }

        private string CalculateSize(long bytes)
        {
            var suffix = new[] { "B", "KB", "MB", "GB", "TB" };
            float byteNumber = bytes;
            for (var i = 0; i < suffix.Length; i++)
            {
                if (byteNumber < 1000)
                {
                    if (i == 0) return $"{byteNumber} {suffix[i]}";
                    else
                    {
                        return $"{byteNumber:0.#0} {suffix[i]}";
                    }
                }
                else
                {
                    byteNumber /= 1024;
                }
            }
            return $"{byteNumber:N} {suffix[suffix.Length - 1]}";
        }

        private long GetDirectorySize(string directoryPath)
        {
            try
            {
                var d = new DirectoryInfo(directoryPath);
                return d.EnumerateFiles("*", System.IO.SearchOption.AllDirectories).Sum(fi => fi.Length);
            }
            catch (UnauthorizedAccessException) { return 0; }
            catch (FileNotFoundException) { return 0; }
            catch (DirectoryNotFoundException) { return 0; }
        }

        private void BgGetFilesSize_DoWork(object? sender, DoWorkEventArgs e)
        {
            var FileSize = _navigatedFolderFiles.Where(File => File.IsSelected && !File.IsDirectory)
                .Sum(x => new FileInfo(x.Path).Length);

            _mainWindowViewModel.SelectedFolderDetails = CalculateSize(FileSize);

            var Directories = _navigatedFolderFiles.Where(directory => directory.IsSelected && directory.IsDirectory);
            try
            {
                foreach (var directory in Directories)
                {
                    FileSize += GetDirectorySize(directory.Path);
                    _mainWindowViewModel.SelectedFolderDetails = CalculateSize(FileSize);
                }
            }
            catch (InvalidOperationException) { }
        }
    }
}

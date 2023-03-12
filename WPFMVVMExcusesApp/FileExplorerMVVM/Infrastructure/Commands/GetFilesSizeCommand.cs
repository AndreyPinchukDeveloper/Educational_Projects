using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class GetFilesSizeCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public ObservableCollection<FileDetailsModel> NavigatedFolderFiles { get; set; }
        public string SelectedFolderDetails;
        internal ReadOnlyCollection<string> tempFolderCollection;
        private string _currentDirectory { get; set; }
        //MainWindowViewModel mainWindowViewModel;

        BackgroundWorker bgGetFiles;

        BackgroundWorker bgGetFilesSize;

        public GetFilesSizeCommand(MainWindowViewModel mainWindowViewModel, BackgroundWorker bgGetFiles, BackgroundWorker bgGetFilesSize, string SelectedFolderDetails, 
            ObservableCollection<FileDetailsModel> NavigatedFolderFiles, ReadOnlyCollection<string> tempFolderCollection, string currentDirectory)
        {
            _mainWindowViewModel = mainWindowViewModel;
            this.bgGetFiles = bgGetFiles;
            this.bgGetFilesSize = bgGetFilesSize;
            this.SelectedFolderDetails = SelectedFolderDetails;
            this.NavigatedFolderFiles = NavigatedFolderFiles;
            NavigatedFolderFiles = new ObservableCollection<FileDetailsModel>();
            this.tempFolderCollection = tempFolderCollection;
            _currentDirectory = currentDirectory;
            _mainWindowViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainWindowViewModel.SelectedFolderDetails))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            var file = parameter as FileDetailsModel;
            if (file == null) return;
            SelectedFolderDetails = "Calculating size...";

            //OnPropertyChanged(nameof(SelectedFolderDetails));

            bgGetFilesSize.DoWork -= BgGetFilesSize_DoWork;
            bgGetFilesSize.DoWork += BgGetFilesSize_DoWork;

            if (bgGetFilesSize.IsBusy) bgGetFilesSize.CancelAsync();
            if (bgGetFilesSize.CancellationPending)
            {
                bgGetFiles.Dispose();
                bgGetFiles = new BackgroundWorker()
                {
                    WorkerSupportsCancellation = true
                };
            }

            bgGetFilesSize.RunWorkerAsync();
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
            var FileSize = NavigatedFolderFiles.Where(File => File.IsSelected && !File.IsDirectory)
                .Sum(x => new FileInfo(x.Path).Length);

            SelectedFolderDetails = CalculateSize(FileSize);
            //OnPropertyChanged(nameof(SelectedFolderDetails));

            var Directories = NavigatedFolderFiles.Where(directory => directory.IsSelected && directory.IsDirectory);
            try
            {
                foreach (var directory in Directories)
                {
                    FileSize += GetDirectorySize(directory.Path);
                    SelectedFolderDetails = CalculateSize(FileSize);
                    //OnPropertyChanged(nameof(SelectedFolderDetails));
                }
            }
            catch (InvalidOperationException) { }
        }
    }
}

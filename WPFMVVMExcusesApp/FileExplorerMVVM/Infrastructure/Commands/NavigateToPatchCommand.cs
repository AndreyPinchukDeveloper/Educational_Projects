using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.Models;
using FileExplorerMVVM.ViewModels;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class NavigateToPatchCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public NavigateToPatchCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
        public override void Execute(object? parameter)
        {
            var path = parameter as string;
            if (!string.IsNullOrEmpty(path)) 
            {
                _mainWindowViewModel.GetFilesListCommand.Execute(new FileDetailsModel()
                {
                    Path = path
                });
            }
        }
    }
}

using YouTubeViewersWPF.Commands.Base;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels;

namespace YouTubeViewersWPF.Commands
{
    public class OpenAddYouTubeViewerCommand : BaseCommand
    {
        //new
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddYouTubeViewerCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddYouTubeViewerViewModel addYouTubeViewerViewModel = new AddYouTubeViewerViewModel();
            _modalNavigationStore.CurrentViewModel = addYouTubeViewerViewModel;
        }
    }
}

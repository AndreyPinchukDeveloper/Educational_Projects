using YouTubeViewersWPF.Commands.Base;
using YouTubeViewersDomain.Models;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels;

namespace YouTubeViewersWPF.Commands
{
    public class OpenAddYouTubeViewerCommand : BaseCommand
    {
        private readonly YouTubeViewerStore _youTubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddYouTubeViewerCommand(
            YouTubeViewerStore youTubeViewerStore, 
            ModalNavigationStore modalNavigationStore)
        {
            _youTubeViewerStore = youTubeViewerStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddYouTubeViewerViewModel addYouTubeViewerViewModel = new AddYouTubeViewerViewModel(_youTubeViewerStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addYouTubeViewerViewModel;
            
        }
    }
}

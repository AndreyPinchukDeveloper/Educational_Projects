using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersWPF.Commands.Base;
using YouTubeViewersWPF.Models;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels;

namespace YouTubeViewersWPF.Commands
{
    public class OpenEditYouTubeViewerCommand:BaseCommand
    {
        private readonly YouTubeViewersListingItemViewModel _youTubeViewersListingItemViewModel;
        private readonly YouTubeViewerStore _youTubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore; 
        

        public OpenEditYouTubeViewerCommand(
            YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel,
            YouTubeViewerStore youTubeViewerStore,
            ModalNavigationStore modalNavigationStore)
        {
            _youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
            _youTubeViewerStore = youTubeViewerStore;
            _modalNavigationStore = modalNavigationStore; 
        }

        public override void Execute(object? parameter)
        {
            YouTubeViewer youTubeViewer = _youTubeViewersListingItemViewModel.YouTubeViewer;

            EditYouTubeViewerViewModel editYouTubeViewerViewModel = new EditYouTubeViewerViewModel(youTubeViewer, _youTubeViewerStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editYouTubeViewerViewModel;
        }
    }
}

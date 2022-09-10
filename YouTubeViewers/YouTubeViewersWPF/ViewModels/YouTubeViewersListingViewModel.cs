using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YouTubeViewersWPF.Commands;
using YouTubeViewersWPF.Models;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    public class YouTubeViewersListingViewModel:ViewModelBase
    {
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        //ObservableCollection notify otside objects that collection was changed
        //our UI automaticly update while we add or remove oblects
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;
        
        //YouTubeViewersListingItemViewModels bind with ListView Listing controller
        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels =>
            _youTubeViewersListingItemViewModels;

        private YouTubeViewersListingItemViewModel _selectedYouTubeViewerListingItemViewModel;

        public YouTubeViewersListingItemViewModel SelectedYouTubeViewerListingItemViewModel
        {
            get { return _selectedYouTubeViewerListingItemViewModel; }
            set 
            { 
                _selectedYouTubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));

                _selectedYouTubeViewerStore.SelectedYouTubeViewer = _selectedYouTubeViewerListingItemViewModel?.YouTubeViewer;
            }
        }

        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            AddYouTubeViewer(new YouTubeViewer("Andre", true, false), modalNavigationStore);
            AddYouTubeViewer(new YouTubeViewer("Inessa", false, true), modalNavigationStore);
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer, ModalNavigationStore modalNavigationStore)
        {
            ICommand editCommand = new OpenEditYouTubeViewerCommand(modalNavigationStore, youTubeViewer);
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(youTubeViewer, editCommand));
        }
    }
}

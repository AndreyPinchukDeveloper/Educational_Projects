using System;
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
        private readonly YouTubeViewerStore _youTubeViewerStore;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

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

        public YouTubeViewersListingViewModel(YouTubeViewerStore youTubeViewerStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            _youTubeViewerStore = youTubeViewerStore;
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _modalNavigationStore = modalNavigationStore;
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            _youTubeViewerStore.YouTubeViewerAdded += YouTubeViewerStore_YouTubeViewerAdded;
        _youTubeViewerStore.YouTubeViewerUpdated += YouTubeViewerStore_YouTubeViewerUpdated;
        }

        protected override void Dispose()
        {
            _youTubeViewerStore.YouTubeViewerAdded -= YouTubeViewerStore_YouTubeViewerAdded;
            _youTubeViewerStore.YouTubeViewerUpdated -= YouTubeViewerStore_YouTubeViewerUpdated;

            base.Dispose();
        }

        private void YouTubeViewerStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
        {
            AddYouTubeViewer(youTubeViewer);
        }


        private void YouTubeViewerStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            throw new NotImplementedException();
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            ICommand editCommand = new OpenEditYouTubeViewerCommand(_modalNavigationStore, youTubeViewer);
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(youTubeViewer, editCommand));
        }
    }
}

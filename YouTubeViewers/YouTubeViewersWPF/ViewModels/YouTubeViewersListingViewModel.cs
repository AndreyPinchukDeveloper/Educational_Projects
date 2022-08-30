using System.Collections.Generic;
using System.Collections.ObjectModel;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    public class YouTubeViewersListingViewModel:ViewModelBase
    {
        //ObservableCollection notify otside objects that collection was changed
        //our UI automaticly update while we add or remove oblects
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;
        //YouTubeViewersListingItemViewModels bind with ListView Listing controller
        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels =>
            _youTubeViewersListingItemViewModels;

        private YouTubeViewersListingItemViewModel myVar;

        public YouTubeViewersListingItemViewModel MyPropSelectedYouTubeViewersListingItemViewModelserty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel("Inessa"));
        }
    }
}

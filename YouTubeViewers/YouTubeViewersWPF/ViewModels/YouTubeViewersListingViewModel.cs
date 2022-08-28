using System.Collections.Generic;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    public class YouTubeViewersListingViewModel:ViewModelBase
    {
        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels{get; { get; set; }
    }
}

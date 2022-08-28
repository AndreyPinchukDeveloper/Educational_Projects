using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    public class YouTubeViewersViewModel:ViewModelBase
    {
        /// <summary>
        /// These 3 ones we're binding with View part(YouTubeViewersView) 
        /// </summary>
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
        public ICommand AddYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel()
        {
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel();
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel();
        }
    }
}

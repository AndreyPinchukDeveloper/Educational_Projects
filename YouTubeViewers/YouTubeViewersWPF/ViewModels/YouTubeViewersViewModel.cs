using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewersWPF.Commands;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    /// <summary>
    /// This VM is binding with main window, it shows list of users and details about them
    /// also this VM is binding with Open AddCommand for button
    /// </summary>
    public class YouTubeViewersViewModel:ViewModelBase
    {
        /// <summary>
        /// These 3 ones we're binding with View part(YouTubeViewersView) 
        /// </summary>
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
        public ICommand AddYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel(YouTubeViewerStore youTubeViewerStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(youTubeViewerStore, selectedYouTubeViewerStore, modalNavigationStore);
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);
            AddYouTubeViewersCommand = new OpenAddYouTubeViewerCommand(youTubeViewerStore, modalNavigationStore);
        }
    }
}

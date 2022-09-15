using System.Windows.Input;
using YouTubeViewersWPF.Commands;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    public class AddYouTubeViewerViewModel:ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get;}
        public AddYouTubeViewerViewModel(YouTubeViewerStore youTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {

            ICommand submitCommand = new AddYouTubeViewerCommand(this, youTubeViewerStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}

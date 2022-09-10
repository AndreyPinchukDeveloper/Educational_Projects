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
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly YouTubeViewer _youTubeViewer;

        public OpenEditYouTubeViewerCommand(ModalNavigationStore modalNavigationStore, YouTubeViewer youTubeViewer)
        {
            _modalNavigationStore = modalNavigationStore;
            _youTubeViewer = youTubeViewer;
        }

        public override void Execute(object? parameter)
        {
            EditYouTubeViewerViewModel editYouTubeViewerViewModel = new EditYouTubeViewerViewModel(_youTubeViewer,_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editYouTubeViewerViewModel;
        }
    }
}

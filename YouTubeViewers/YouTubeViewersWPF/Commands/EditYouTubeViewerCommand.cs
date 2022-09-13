using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersWPF.Commands.Base;
using YouTubeViewersWPF.Stores;

namespace YouTubeViewersWPF.Commands
{
    public class EditYouTubeViewerCommand:AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditYouTubeViewerCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _modalNavigationStore.Close();
        }
    }
}

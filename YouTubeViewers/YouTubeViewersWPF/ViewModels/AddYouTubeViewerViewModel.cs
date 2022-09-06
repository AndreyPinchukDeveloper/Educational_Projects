using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    public class AddYouTubeViewerViewModel:ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get;}
        public AddYouTubeViewerViewModel()
        {
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel();
        }
    }
}

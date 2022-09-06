using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    public class EditYouTubeViewerViewModel:ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }
        public EditYouTubeViewerViewModel()
        {
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel();
        }
    }
}

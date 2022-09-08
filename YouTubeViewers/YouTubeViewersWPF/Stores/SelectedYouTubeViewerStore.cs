using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersWPF.Models;

namespace YouTubeViewersWPF.Stores
{
    public class SelectedYouTubeViewerStore
    {
        private YouTubeViewer _selectedYouTubeViewer;

        public YouTubeViewer SelectedYouTubeViewer
        {
            get { return _selectedYouTubeViewer; }
            set 
            { 
                _selectedYouTubeViewer = value;
                SelectedYouTubeViewerChanged?.Invoke();
            }
        }

        /// <summary>
        /// This delegate need us to notify our view if SelectedYouTubeViewer was changed
        /// 
        /// note: Action don't return a value, unlike Func
        /// </summary>
        public event Action SelectedYouTubeViewerChanged;
    }
}

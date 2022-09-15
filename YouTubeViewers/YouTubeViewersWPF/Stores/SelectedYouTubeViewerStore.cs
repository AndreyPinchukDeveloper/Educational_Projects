using System;
using YouTubeViewersWPF.Models;

namespace YouTubeViewersWPF.Stores
{
    public class SelectedYouTubeViewerStore
    {
        private readonly YouTubeViewerStore _youTubeViewerStore;

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

        public SelectedYouTubeViewerStore(YouTubeViewerStore youTubeViewerStore)
        {
            _youTubeViewerStore = youTubeViewerStore;
            _youTubeViewerStore.YouTubeViewerUpdated += YouTubeViewerStore_YouTubeViewerUpdated;
        }

        private void YouTubeViewerStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            if (youTubeViewer.Id == SelectedYouTubeViewer?.Id)
            {
                SelectedYouTubeViewer = youTubeViewer;
            }
        }
    }
}

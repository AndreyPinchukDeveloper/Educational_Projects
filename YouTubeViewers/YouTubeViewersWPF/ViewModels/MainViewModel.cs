using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    /// <summary>
    /// This VM is shell for app, it's going to get current VM
    /// from modal navigation store and display that in the MainWindow
    /// </summary>
    public class MainViewModel:ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public YouTubeViewersViewModel YouTubeViewersViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, YouTubeViewersViewModel youTubeViewersViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            YouTubeViewersViewModel = youTubeViewersViewModel;
            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModel = new AddYouTubeViewerViewModel();
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;
            base.Dispose();
        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}

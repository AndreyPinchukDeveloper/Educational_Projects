 using System.Windows;
using YouTubeViewersWPF.Stores;
using YouTubeViewersWPF.ViewModels;

namespace YouTubeViewersWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly YouTubeViewerStore _youTubeViewerStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _selectedYouTubeViewersStore = new SelectedYouTubeViewerStore();
            _youTubeViewerStore = new YouTubeViewerStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            YouTubeViewersViewModel youTubeViewersViewModel = new YouTubeViewersViewModel(
                _youTubeViewerStore,
                _selectedYouTubeViewersStore, 
                _modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, youTubeViewersViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

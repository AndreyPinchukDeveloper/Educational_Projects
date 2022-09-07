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

        public App()
        {
            _selectedYouTubeViewersStore = new SelectedYouTubeViewerStore();
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            YouTubeViewersViewModel youTubeViewersViewModel = new YouTubeViewersViewModel(_selectedYouTubeViewersStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, youTubeViewersViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

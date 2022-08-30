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

        public App()
        {
            _selectedYouTubeViewersStore = new SelectedYouTubeViewerStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new YouTubeViewersViewModel(_selectedYouTubeViewersStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}

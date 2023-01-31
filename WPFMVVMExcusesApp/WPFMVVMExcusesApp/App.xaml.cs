using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMExcusesApp.Infrastructure.Stores;
using WPFMVVMExcusesApp.Models;
using WPFMVVMExcusesApp.ViewModels.Controllers;
using WPFMVVMExcusesApp.ViewModels.Windows;

namespace WPFMVVMExcusesApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            //navigationStore.CurrentViewModel = new ExcuseViewModel(this,navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

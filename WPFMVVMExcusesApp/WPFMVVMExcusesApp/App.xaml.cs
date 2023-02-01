using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMExcusesApp.Infrastructure.HostBuilders;
using WPFMVVMExcusesApp.Infrastructure.Services;
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
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((services) =>
                {
                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<MainWindowViewModel>();
                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainWindowViewModel>()
                    });
                }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            NavigationService<OperateExcuseViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<OperateExcuseViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

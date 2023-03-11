using FileExplorerMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Infrastructure.HostBuilders
{
    public static class MainWindowHostBuilderExtensions
    {
        public static IHostBuilder MainWindow(this IHostBuilder hostBuilder) 
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient((s) => CreateMainWindowViewModel(s));
                services.AddSingleton<Func<MainWindowViewModel>>
                ((s) => () => s.GetRequiredService<MainWindowViewModel>());
            });

            return hostBuilder;
        }

        private static MainWindowViewModel CreateMainWindowViewModel(IServiceProvider services)
        {
            return MainWindowViewModel.LoadViewModel();
        }
    }
}

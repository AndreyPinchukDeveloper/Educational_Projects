using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMExcusesApp.Infrastructure.Services;
using WPFMVVMExcusesApp.ViewModels.Controllers;

namespace WPFMVVMExcusesApp.Infrastructure.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient((s) => CreateOperateExcuseViewModel(s));
                services.AddSingleton<Func<OperateExcuseViewModel>>((s) => () => s.GetRequiredService<OperateExcuseViewModel>());
                services.AddSingleton<NavigationService<OperateExcuseViewModel>>();
            });

            return hostBuilder;
        }

        private static OperateExcuseViewModel CreateOperateExcuseViewModel(IServiceProvider serviceProvider) 
        {
            OperateExcuseViewModel operateExcuseViewModel = new OperateExcuseViewModel(); 
            return operateExcuseViewModel;
        }
    }
}

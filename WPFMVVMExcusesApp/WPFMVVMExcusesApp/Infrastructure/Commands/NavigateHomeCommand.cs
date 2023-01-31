using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMExcusesApp.Infrastructure.Commands.Base;
using WPFMVVMExcusesApp.Infrastructure.Stores;
using WPFMVVMExcusesApp.ViewModels.Controllers;

namespace WPFMVVMExcusesApp.Infrastructure.Commands
{
    public class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateHomeCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            //_navigationStore.CurrentViewModel = new ExcuseViewModel();
        }
    }
}

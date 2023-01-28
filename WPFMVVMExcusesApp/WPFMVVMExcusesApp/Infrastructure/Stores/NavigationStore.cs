using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMExcusesApp.ViewModels.Base;

namespace WPFMVVMExcusesApp.Infrastructure.Stores
{
    /// <summary>
    /// This class is store current view model for application
    /// </summary>
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Disose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private event Action CurrentViewModelChanged;
        /// <summary>
        /// This method invoke method given from another class by using delegate 
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }


    }
}

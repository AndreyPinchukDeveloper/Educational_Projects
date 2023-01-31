using System;
using System.Windows.Input;
using WPFMVVMExcusesApp.Infrastructure.Commands;
using WPFMVVMExcusesApp.Infrastructure.Stores;
using WPFMVVMExcusesApp.Models;
using WPFMVVMExcusesApp.ViewModels.Base;

namespace WPFMVVMExcusesApp.ViewModels.Controllers
{
    public class ExcuseViewModel:ViewModelBase
    {
        private readonly ExcuseModel _excuseModel;

        public string ExcuseName => _excuseModel.ExcuseName;
        public string ExcuseResult => _excuseModel.ExcuseResult;
        public DateTime LastUsed => _excuseModel.LastUsed;
        public DateTime SaveToDbDate => _excuseModel.SaveToDbDate;
        //public ICommand NavigateHomeCommand { get; }

        public ExcuseViewModel(ExcuseModel excuseModel, NavigationStore navigationStore)
        {
            _excuseModel = excuseModel;
            //NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
        }

        
    }
}

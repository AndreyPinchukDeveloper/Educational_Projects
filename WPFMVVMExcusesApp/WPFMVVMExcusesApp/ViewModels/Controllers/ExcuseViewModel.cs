using System;
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

        public ExcuseViewModel(ExcuseModel excuseModel)
        {
            _excuseModel = excuseModel;
        }
    }
}

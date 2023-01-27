using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMExcusesApp.Models;
using WPFMVVMExcusesApp.ViewModels.Base;

namespace WPFMVVMExcusesApp.ViewModels
{
    public class ExcuseViewModel:ViewModelBase
    {
        private readonly ExcuseModel _excuseModel;

        public string ExcuseName => _excuseModel.ExcuseName;
        public string ExcuseResult => _excuseModel.ExcuseResult;
        public DateTime StartDate => _excuseModel.StartDate;
        public DateTime SaveToDbDate => _excuseModel.SaveToDbDate;

        public ExcuseViewModel(ExcuseModel excuseModel)
        {
            _excuseModel = excuseModel;
        }
    }
}

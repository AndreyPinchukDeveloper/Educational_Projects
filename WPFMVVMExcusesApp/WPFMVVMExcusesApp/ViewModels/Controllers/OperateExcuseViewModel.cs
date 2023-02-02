using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMExcusesApp.Infrastructure.Commands;
using WPFMVVMExcusesApp.ViewModels.Base;

namespace WPFMVVMExcusesApp.ViewModels.Controllers
{
    public class OperateExcuseViewModel:ViewModelBase
    {
        #region Fields
        private string _excuseName;

        public string ExcuseName
        {
            get => _excuseName;
            set => Set(ref _excuseName, value);
        }

        private string _excuseResult;

        public string ExcuseResult
        {
            get => _excuseResult;
            set => Set(ref _excuseResult, value);
        }

        private DateTime _lastUsed;
        public DateTime LastUsed
        {
            get => _lastUsed;
            set => Set(ref _lastUsed, value);
        }

        private DateTime _saveToDbDate;
        public DateTime SaveToDbDate
        {
            get => _saveToDbDate;
            set => Set(ref _saveToDbDate, value);
        }
        #endregion

        public ICommand OpenFolderCommand { get; }
        public OperateExcuseViewModel()
        {
            OpenFolderCommand = new OpenFolderCommand();
        }
    }
}

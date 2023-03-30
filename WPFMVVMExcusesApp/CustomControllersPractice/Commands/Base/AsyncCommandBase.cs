using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControllersPractice.Commands.Base
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecuting;
        public bool IsExecuting
        {
            get { return _isExecuting; }
            set { _isExecuting= value; OnCanExecuteChanged(); }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object parameter)
        {
            IsExecuting = true;
            try
            {
                ExecuteAsync(parameter);
            }
            finally { IsExecuting = false; }
            
        }

        private void OnCanExecuteChanged()
        {
            throw new NotImplementedException();
        }

        public abstract Task ExecuteAsync(object parameter);

    }
}

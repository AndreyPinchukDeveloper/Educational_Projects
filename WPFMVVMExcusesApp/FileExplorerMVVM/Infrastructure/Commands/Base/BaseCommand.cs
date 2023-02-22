using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileExplorerMVVM.Infrastructure.Commands.Base
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    #region ExampleClass
    public class Command : ICommand
    {
        private readonly Action _action;
        public Command(Action action)
        {
            _action = action;
        }

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
    #endregion
}

using System;
using System.Windows.Input;

namespace YouTubeViewersWPF.Commands.Base
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected virtual void OnCanExecutedCHanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

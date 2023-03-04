using FileExplorerMVVM.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class OpenWindowsSettingsCommand : BaseCommand
    {
        private readonly Action _action;
        public OpenWindowsSettingsCommand(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// just call method that was given as parameter in ctor
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}

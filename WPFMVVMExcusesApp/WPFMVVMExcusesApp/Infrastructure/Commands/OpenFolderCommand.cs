using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMExcusesApp.Infrastructure.Commands.Base;

namespace WPFMVVMExcusesApp.Infrastructure.Commands
{
    public class OpenFolderCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            OpenFolder();
        }

        private void OpenFolder()
        {
            RadOpenFileDialog
        }
    }
}

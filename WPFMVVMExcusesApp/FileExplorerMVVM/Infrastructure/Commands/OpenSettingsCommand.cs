using FileExplorerMVVM.Infrastructure.Commands.Base;
using System.Diagnostics;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class OpenSettingsCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            Process.Start(new ProcessStartInfo { FileName = "ms-settings:settings", UseShellExecute = true });
        }

    }
}

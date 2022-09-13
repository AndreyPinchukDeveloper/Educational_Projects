using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewersWPF.Commands.Base
{
    public abstract class AsyncCommandBase : BaseCommand
    {
        public async override void Execute(object? parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}

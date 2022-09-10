using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersWPF.Commands.Base;
using YouTubeViewersWPF.Stores;

namespace YouTubeViewersWPF.Commands
{
    /// <summary>
    /// Command to close AddViewer window.
    /// </summary>
    public class CloseModalCommand : BaseCommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public CloseModalCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            _modalNavigationStore.Close();
        }
    }
}

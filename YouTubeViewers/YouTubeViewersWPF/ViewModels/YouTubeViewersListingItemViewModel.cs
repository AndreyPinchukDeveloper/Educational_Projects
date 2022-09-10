using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewersWPF.Models;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.ViewModels
{
    public class YouTubeViewersListingItemViewModel:ViewModelBase
    {
        public YouTubeViewer YouTubeViewer { get; }

        public string Username => YouTubeViewer.Username;
        public ICommand DeleteCommand { get;}
        public ICommand EditCommand { get;}

        public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer, ICommand editCommand)
        {
            YouTubeViewer = youTubeViewer;
            EditCommand = editCommand;
        }
    }
}

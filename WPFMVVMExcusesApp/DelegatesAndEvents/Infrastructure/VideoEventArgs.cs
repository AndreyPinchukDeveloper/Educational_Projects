using DelegatesAndEvents.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents.Infrastructure
{
    public class VideoEventArgs:EventArgs
    {
        public VideoModel Video { get; set; }
    }
}

using DelegatesAndEvents.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents.Infrastructure
{
    public class VideoEncoder
    {
        /*public delegate void VideEncodedEventHandler(object source, VideoEventArgs args);
        public event VideEncodedEventHandler VideoEncoded;*/


        public event EventHandler<VideoEventArgs> VideoEncoded;//it's the same as above
        public void Encode(VideoModel video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(2000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(VideoModel video)
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video = video});
            }
        }
    }
}
  
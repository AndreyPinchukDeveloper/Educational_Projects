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
        public delegate void VideEncodedEventHandler(object source, EventArgs args);
        public event VideEncodedEventHandler VideoEncoded;

        public void Encode(VideoModel video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(2000);

            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, EventArgs.Empty);
            }
        }
    }
}
  
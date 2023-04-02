using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents.Services
{
    public class MessageService
    {
        public void OnMessageEncoded(object source, EventArgs e)
        {
            Console.WriteLine("Message service: the message is encoding...");
        }
    }
}

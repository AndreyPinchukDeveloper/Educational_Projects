using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdvancedDelegates
{
    public class DelegateExample
    {
        delegate void LogDelegate(string text, DateTime dateTime);
        LogDelegate logDelegate = new LogDelegate(LogTextToScreen);

        public void ReturnDelegateResult()
        {
            Console.WriteLine("What's your name ?");
            var name = Console.ReadLine();
            logDelegate(name, DateTime.UtcNow);
            Console.ReadKey();
        }
        
        private static void LogTextToScreen(string text, DateTime dateTime)
        {
            Console.WriteLine($"{dateTime}: {text}");
        }
    }
}

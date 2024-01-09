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
        delegate void LogDelegate(string text);
        LogDelegate logDelegateToScreen = new LogDelegate(LogTextToScreen);
        LogDelegate logDelegateToFile = new LogDelegate(LogTextToFile);

        public void ReturnDelegateResult()
        {
            Console.WriteLine("What's your name ?");
            var name = Console.ReadLine();
            logDelegateToScreen(name);
            logDelegateToFile(name);
            DelegateSum(logDelegateToScreen, logDelegateToFile);

            Console.ReadKey();
        }
        
        private static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        private static void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }

        private static void DelegateSum(LogDelegate first, LogDelegate second)
        {
           LogDelegate multiDelegate = first + second;
        }
    }
}

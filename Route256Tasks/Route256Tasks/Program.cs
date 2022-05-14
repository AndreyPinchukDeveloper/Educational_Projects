using System;
using System.Linq;

namespace Route256Tasks
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCaseCount; i++)
            {
                var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
                Console.WriteLine(collection.Sum());
            }

            /*int secondValue = 0;
            try
            {
                while (secondValue >= -1000 && secondValue >= 1000)
                {
                    int firstValue = Convert.ToInt32(Console.ReadLine());
                    secondValue = Convert.ToInt32(Console.ReadLine());
                    SumOfTwoNumbers(firstValue, secondValue);
                }
            }
            catch (Exception)
            {
                throw;
            }*/

        }
        private static int SumOfTwoNumbers(int first, int second)
        {
            int sum = 0 ;
            sum = first + second;
            Console.WriteLine(sum);
            return sum;
        }
    } 
}

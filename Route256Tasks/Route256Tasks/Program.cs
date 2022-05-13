using System;

namespace Route256Tasks
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int firstValue = 0;
            int secondValue = 0;
            while (true)
            {
                int value = Convert.ToInt32(Console.ReadLine());
                firstValue = value;
                int second = Convert.ToInt32(Console.ReadLine());
                secondValue = value;
                SumOfTwoNumbers(firstValue,secondValue);
            }
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

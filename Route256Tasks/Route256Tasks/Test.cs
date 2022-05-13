using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256Tasks
{
    public class Kata
    {
        public static int[][] Pyramid(int n)
        {
            int[][] array = new int[n][];
            int valueToCountArray = n - 1;

            for (int i = 0; i < n; i++)
            {
                array[i] = new int[i + 1];
            }

            if (n == 0)
            {
                return array;
            }
            else if (n == 1)
            {
                array[valueToCountArray].SetValue(1, 0);
            }

            else if (n > 0)
            {
                while (valueToCountArray >= 0)
                {
                    for (int i = 0; i <= valueToCountArray; i++)
                    {
                        array[valueToCountArray].SetValue(1, i);
                    }
                    valueToCountArray--;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < array[i].Length; j++)
                {
                    System.Console.Write("{0}{1}", array[i][j], j == (array[i].Length - 1) ? "" : " ");
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
            Console.WriteLine(array.Length);
            return array;
        }
    }
}

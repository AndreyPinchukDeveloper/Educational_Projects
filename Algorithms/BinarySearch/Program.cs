using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] myArray = new int[] { 1,2,3,4,5};
            BinarySearch(myArray, 6);
            Console.ReadLine();

        }
        private static bool BinarySearch(int[] array, int valueToFind)
        {
            bool content = false;
            int lowerValue = 0;
            int higherValue = array.Length - 1;

            while (lowerValue<=higherValue)
            {
                int middle = lowerValue + higherValue;//4
                int value = array[middle];
                if (value == valueToFind)
                {
                    Console.WriteLine("true");
                    return content = true;
                }
                else if (value>valueToFind)
                {
                    higherValue = middle - 1;
                }
                else if (value<valueToFind)
                {
                    lowerValue = middle + 1;
                }
            }
            Console.WriteLine("false");
            return content;
        }
    } 
}

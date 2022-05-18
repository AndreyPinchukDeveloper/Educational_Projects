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
            BinarySearch(myArray, 4);

        }
        private static bool BinarySearch(int[] array, int valueToFind)
        {
            bool content = true;
            int lowerValue = 0;
            int higherValue = array.Length - 1;
            int middle = 0;

            while (lowerValue<=higherValue)
            {

            }

            return content;
        }
    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    internal class TestClass
    {
        int[] myArray = new int[5] { 1, 2, 3, 4, 5 };

        private int Sum()
        {
            int sum = 0;
            int i = 0;
            while (sum<myArray.Sum())
            {
                sum = myArray[0] + myArray[i];
                i++;
                Sum();
            }
            return sum;
        }
    }
}

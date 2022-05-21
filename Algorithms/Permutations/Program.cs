using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class Program
    {
        private static List<string> _permutationsList = new List<string>() {};
        Random random = new Random();
        static void Main(string[] args)
        {
            string andre = "aabb";
            SinglePermutations(andre);
            Console.ReadLine();
        }

        public static List<string> SinglePermutations(string s)
        {
            char[] newArray = s.ToCharArray();
            AddToList(newArray);
            RecPermutation(newArray);
            return _permutationsList;
        }

        public static void RecPermutation(char[] charArray)
        {
            bool repeat = true;
            int stringLength = charArray.Length;

            for (var i = 0; i < stringLength; i++)
            {
                var temp = charArray[stringLength - 1];
                for (var j = stringLength - 1; j > 0; j--)//this loop making "ttes" from "test" last letter became first, another letters move to right
                {
                    charArray[j] = charArray[j - 1];
                }
                charArray[0] = temp;//last letter became first
                if (i < stringLength - 1)
                {
                    AddToList(charArray, repeat);
                }
            }

            Array.Reverse(charArray);
            AddToList(charArray);

            for (var i = 0; i < stringLength; i++)
            {
                var temp = charArray[stringLength - 1];
                for (var j = stringLength - 1; j > 0; j--)
                {
                    charArray[j] = charArray[j - 1];
                }
                charArray[0] = temp;
                if (i < stringLength-1)
                {
                    AddToList(charArray, repeat);
                }
                else
                {
                    return;
                }
            }
        }

        public static void AddToList(char[] charArray, bool repeat = true)
        {
            var bufer = new StringBuilder("");
            for (int i = 0; i < charArray.Count(); i++)
            {
                bufer.Append(charArray[i]);
            }
            if (repeat && !_permutationsList.Contains(bufer.ToString()))
            {
                _permutationsList.Add(bufer.ToString());
            }

        }

        //new method to shuffle all elements
        private void ShuffleArray()
        {

        }
    }
}

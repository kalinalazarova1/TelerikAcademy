using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int bestIndex = 0;
            int elemCount;
            int bestCount = 1;
            int[] arr = new int[] { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 4 };
            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                elemCount = 1;
                for (int j = i + 1; j < arr.GetLength(0); j++)
                {
                    if (arr[i] == arr[j])
                    {
                        elemCount++;
                    }
                }
                if (elemCount > bestCount)
                {
                    bestCount = elemCount;
                    bestIndex = i;
                }

            }
            Console.WriteLine("Най-често срещаният елемент е: " + arr[bestIndex]);
            Console.WriteLine("Той се среща " + bestCount + " пъти.");
         }
    }
}

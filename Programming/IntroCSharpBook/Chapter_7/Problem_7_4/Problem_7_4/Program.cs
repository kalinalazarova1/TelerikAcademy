using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int areaStart = 0;
            int bestStart = 0;
            int areaLength = 1;
            int bestLength = 1;
            int[] array = new int [] { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            for (int i = 0; i < (array.GetLength(0) - 1); i++)
            {
                if (array[i] != array[i + 1])
                {
                    areaStart = i + 1;
                    areaLength = 1;
                }
                else
                {
                    areaLength++;
                    if (areaLength > bestLength)
                    {
                        bestLength = areaLength;
                        bestStart = areaStart;
                    }
                }
            }
            for(int i = bestStart; i < (bestStart + bestLength); i++)
            {
                Console.Write(array[i] + " ");
            }
            
        }
    }
}

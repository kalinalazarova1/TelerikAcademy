using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //програмата не работи коректно, но условието на задачата е некоректно и посоченото решение също
            int[] array = new int[] { 9, 6, 2, 7, 4, 7, 6, 5, 8, 4 };
            int areaLength;
            int currentElement = 0;
            int[] len = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                areaLength = 1;
                currentElement = i;
                for (int n = i; n < array.GetLength(0) - 1; n++)
                {
                    if(array[currentElement] < array[n + 1])
                    {
                        currentElement = n + 1;
                        areaLength++;
                    }
                }
                len[i] = areaLength;
            }
            currentElement = 0;
            for (int i = 0; i < len.GetLength(0); i++)
            {
                if (len[i] > len[currentElement])
                {
                    currentElement = i;
                }
            }
            Console.Write(array[currentElement] + " ");
            for (int i = currentElement; i < array.GetLength(0) - 1; i++)
            {
                if (array[currentElement] < array[i + 1])
                {
                    Console.Write(array[i + 1] + " ");
                    currentElement = i + 1;
                }
            }
            Console.WriteLine();
        }
    }
}

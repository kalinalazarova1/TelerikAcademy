using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_16
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 2, 3, 3, 3, 4, 6, 7, 8, 9, 11, 13, 14, 15, 17, 23, 34, 36, 38, 39, 42, 49 };
            int minIndex = 0;
            int maxIndex = arr.GetLength(0) - 1;
            Console.WriteLine("Въведете число:");
            int searchKey = Int32.Parse(Console.ReadLine());
            int i = arr.GetLength(0) / 2;
            while ( minIndex < maxIndex && searchKey != arr[i])
            {
                if (searchKey > arr[i])
                {
                    minIndex = i + 1;
                    i = minIndex + (maxIndex - minIndex) / 2;
                }
                else if (searchKey < arr[i])
                {
                    maxIndex = i - 1;
                    i = maxIndex - (maxIndex - minIndex) / 2;
                }
            };
            if (searchKey == arr[i])
            {
                Console.WriteLine("Числото {0} е на {1} позиция в масива.", searchKey, i + 1); 
            }
            else
            {
                Console.WriteLine("Няма такова число в масива.");
            }
        }
    }
}

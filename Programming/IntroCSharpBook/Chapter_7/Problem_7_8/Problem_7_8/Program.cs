using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int minIndex = 0;
            int[] arr = new int[] {3, 4, 6, 2, 0, 1, 6, 9, 5, 5};
            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                minIndex = i;
                for(int j = i + 1; j < arr.GetLength(0) ;j++)
                {
                    if (arr[minIndex] > arr[j])
                    {
                        minIndex = j;
                    }
                }
                    arr[minIndex] = arr[i] - arr[minIndex];
                    arr[i] = arr[i] - arr[minIndex];
                    arr[minIndex] = arr[i] + arr[minIndex];
            }
            Console.Write("Сортираният масив е: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}

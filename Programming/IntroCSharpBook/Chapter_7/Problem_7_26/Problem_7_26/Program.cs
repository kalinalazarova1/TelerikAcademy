using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_26
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 1;
            Console.WriteLine("Моля въведете размер на матрицата:");
            int n = Int32.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            for (int count = 0; count < n; count++)
            {
                for (int row = n - 1, col = n - 1 - count; col < n; row--, col++)
                {
                    arr[row, col] = value;
                    value++;
                }
            }
            for (int count = 0; count < n - 1; count++)
                for (int row = n - 2 - count, col = 0; row >= 0; row--, col++)
                {
                    arr[row, col] = value;
                    value++;
                }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0,3}", arr[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_12a
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 1;
            Console.WriteLine("Моля въведете размер на матрицата:");
            int n = Int32.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    arr[row, col] = value;
                    value++;
                }
            }
            for(int row = 0; row < n; row++)
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

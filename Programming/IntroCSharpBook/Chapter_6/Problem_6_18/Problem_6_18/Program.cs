using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_18
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = 1;
            Console.WriteLine("Моля въведете размер за матрицата:");
            int n = Int32.Parse(Console.ReadLine());
            int [,] array = new int [n,n];
            for (int g = 0; g < (n / 2); g++)
            {
                for (int i = 0 + g; i <= n - 2 - g; i++)
                {
                    array[0 + g, i] = v;
                    v++;
                }
                for (int i = 0 + g; i <= n - 2 - g; i++)
                {
                    array[i, n - 1 - g] = v;
                    v++;
                }
                for (int i = n - 1 - g; i > 0 + g; i--)
                {
                    array[n - 1 - g, i] = v;
                    v++;
                }
                for (int i = n - 1 - g; i > 0 + g; i--)
                {
                    array[i, 0 + g] = v;
                    v++;
                }
                
            }
            if (n % 2 == 1)
            {
                array[n / 2, n / 2] = n * n;
            }
            for (int rows = 0; rows <= n - 1; rows++)
            {
                for (int columns = 0; columns <= n - 1; columns++)
                {
                    Console.Write("{0,3}", array[rows, columns]);
                }
                Console.WriteLine();
            }
        }
    }
}

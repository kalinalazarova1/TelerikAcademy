using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.WriteLine("Моля въведете размер за матрицата по-малък от 20:");
                n = Int32.Parse(Console.ReadLine());
            }
            while (n >= 20);
            for (int i = 1; i <= n; i++)
            {
                for (int m = i; m <= (n + i - 1); m++)
                {
                    Console.Write("{0,3}", m);
                }
                Console.WriteLine();
            }
        }
    }
}

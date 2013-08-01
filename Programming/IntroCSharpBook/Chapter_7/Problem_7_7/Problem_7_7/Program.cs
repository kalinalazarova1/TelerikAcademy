using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int k;
            int bestSum = 0;
            int bestStart = 0;
            Console.WriteLine("Моля въведете размер на масива: ");
            int n = Int32.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Моля въведете елемент " + i + ": ");
                arr[i] = Int32.Parse(Console.ReadLine());
            }
            do
            {
                Console.WriteLine("Моля въведете брой на елементите в масива (той не трябва да надвишава размера на масива: ");
                k = Int32.Parse(Console.ReadLine());
            }
            while (k > n);
            for (int i = 0; i < n - k + 1; i++)
            {
                int sum = 0;
                for (int j = 0; j < k; j++)
                {
                    sum = sum + arr[i + j];
                }
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestStart = i;
                }
            }
            Console.Write("Най-голямата сума е от елементите: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(arr[bestStart + i] + ", ");
            }
            Console.WriteLine();
        }
    }
}

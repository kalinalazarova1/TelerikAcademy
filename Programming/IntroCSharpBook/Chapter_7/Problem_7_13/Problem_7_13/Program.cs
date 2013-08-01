using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Моля въведете първия размер на матрицата");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Моля въведете втория размер на матрицата");
            int m = Int32.Parse(Console.ReadLine());
            int[,] arr = new int[n, m];
            int bestSum, bestRow, bestColumn;
            bestSum = bestRow = bestColumn = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Моля въведете елемент {0}, {1}:", i, j);
                    arr[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = 0; j < m - 2; j++)
                {
                    int sum = 0;
                    sum = arr[i, j] + arr[i, j + 1] + arr[i, j + 2] + arr[i + 1, j] + arr[i + 1 , j + 1] + arr[i + 1, j + 2] + arr[i + 2 , j] + arr[i + 2 , j + 1] + arr[i + 2, j + 2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = i;
                        bestColumn = j;
                    }
                }
            }
            Console.WriteLine("Комбинацията с най-голяма сума е:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0,4}", arr[bestRow + i, bestColumn + j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Най-голямата сумата е: " + bestSum);
        }
    }
}

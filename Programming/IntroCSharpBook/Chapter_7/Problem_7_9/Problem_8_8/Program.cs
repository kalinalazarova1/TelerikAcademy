using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_8_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int bestSum = 0;
            int bestIndex = 0;
            int[] arr = new int[] { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            for (int i = 0; i < (arr.GetLength(0) - 1); i++)
            {
                sum = arr[i];
                for (int j = i + 1; j < arr.GetLength(0) - 1; j++)
                {
                    sum = sum + arr[j];
                    if (bestSum < sum)
                    {
                        bestSum = sum;
                        bestIndex = i;
                    }
                }
            }
            sum = 0;
            Console.Write("Последователността от числа с максимална сума е: ");
            for (int i = bestIndex; sum != bestSum; i++)
            {
                Console.Write(arr[i] + ", ");
                sum = sum + arr[i];
            }
            Console.WriteLine();
            Console.WriteLine("Mаксималната сума е: " + bestSum);
        }
    }
}

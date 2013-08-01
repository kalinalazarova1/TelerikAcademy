using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum;
            int sumIndex = -1;
            int[] arr = new int[] { 4, 3, 1, 4, 2, 5, 8 };
            Console.WriteLine("Моля въведете сума: ");
            int s = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < (arr.GetLength(0) - 1); i++)
            {
                sum = arr[i];
                for (int j = i + 1; j < arr.GetLength(0); j++)
                {
                    sum = sum + arr[j];
                    if (sum == s)
                    {
                        sumIndex = i;
                    }
                }
            }
            if (sumIndex != -1)
            {
                sum = 0;
                Console.Write("Последователността от числа със сума " + s + " е: ");
                for (int i = sumIndex; sum != s; i++)
                {
                    Console.Write(arr[i] + ", ");
                    sum = sum + arr[i];
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Няма числа със сума " + s + " в масива.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Моля въведете максимално число: ");
            int n = Int32.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i + 1;
            }
            Random rand = new Random();
            for (int i = 1; i < (2 * n); i++)
            {
                int temp1 = rand.Next(0, n - 1);
                int temp2 = rand.Next(0, n - 1);
                int value = array[temp1];
                array[temp1] = array[temp2];
                array[temp2] = value;
            }
            for(int i = 0; i < n ; i++)
            {
            Console.Write("{0,3}",array[i]);
            }
            Console.WriteLine();
        }
    }
}

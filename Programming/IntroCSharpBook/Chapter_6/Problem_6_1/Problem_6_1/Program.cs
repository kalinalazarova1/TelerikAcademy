using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Моля въведете крайно число:");
            int n = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6_2
{
    class Problem_6_2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Моля въведете число N:");
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                if ((i % 3) + (i % 7) != 0)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}

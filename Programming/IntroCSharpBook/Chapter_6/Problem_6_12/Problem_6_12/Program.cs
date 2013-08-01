using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, power = 1;
            Console.WriteLine("Моля въведете цяло десетично число: ");
            int n = Int32.Parse(Console.ReadLine());
            do
            {
                power = power * 2;
                i++;
            }
            while (power*2 <= n);
            for (; i > 0; i--)
            {
                Console.Write(n / power);
                n = n % power;
                power = power / 2;

            }
            Console.Write(n);
            Console.WriteLine();
        }
    }
}

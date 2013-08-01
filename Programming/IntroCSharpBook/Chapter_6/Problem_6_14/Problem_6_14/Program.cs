using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_14
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
                power = power * 16;
                i++;
            }
            while (power * 16 <= n);
            for (; i > 0; i--)
            {
                switch (n / power)
                {
                    case 10: Console.Write("A"); break;
                    case 11: Console.Write("B"); break;
                    case 12: Console.Write("C"); break;
                    case 13: Console.Write("D"); break;
                    case 14: Console.Write("E"); break;
                    case 15: Console.Write("F"); break;
                    case 0: break;
                    default: Console.Write(n / power); break;
                };
                n = n % power;
                power = power / 16;

            }
            switch (n)
                {
                    case 10: Console.Write("A"); break;
                    case 11: Console.Write("B"); break;
                    case 12: Console.Write("C"); break;
                    case 13: Console.Write("D"); break;
                    case 14: Console.Write("E"); break;
                    case 15: Console.Write("F"); break;
                    default: Console.Write(n); break;
                };
            Console.WriteLine();
        }
    }
}

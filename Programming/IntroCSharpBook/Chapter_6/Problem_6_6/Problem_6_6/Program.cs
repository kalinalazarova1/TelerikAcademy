using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int factoriel = 1;
            Console.WriteLine("Моля въведете N:");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Моля въведете K по-малко от N:");
            int k = Int32.Parse(Console.ReadLine());
            if (k > n)
            {
                Console.WriteLine("Грешно въведено K!");
            }
            else
            {
                for (int i = k + 1; i <= n; i++)
                {
                    factoriel = factoriel * i;
                }
                Console.WriteLine("N!/K!:" + factoriel);
            }
        }
    }
}

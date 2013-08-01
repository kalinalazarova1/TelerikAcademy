using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_9
{
    class Program
    {
        static void Main(string[] args)
        {
            float sum = 1, power = 1, factoriel = 1;
            Console.WriteLine("Моля въведете броя n за членовете на редицата 1+1!/x+2!/x^2+..n!/x^n:");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Моля въведете x за членовете на редицата 1+1!/x+2!/x^2+..n!/x^n:");
            int x = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                power *= x;
                factoriel = factoriel * i;
                sum = sum + factoriel / power;
            }
            Console.WriteLine("Сумата от членовете на редицата е: " + sum);
        }
    }
}

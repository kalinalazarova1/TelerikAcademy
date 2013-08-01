using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int factorielN = 1, factoriel2N = 1, factorielN1 = 1;
            Console.WriteLine("Моля въведете кое по ред число на Каталан искате да изчислите:");
            int n = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= 2 * n; i++)
            {
                factoriel2N = factoriel2N * i;
                if (i == n)
                {
                    factorielN = factoriel2N;
                }
                if (i == (n + 1))
                {
                    factorielN1 = factoriel2N;
                }
            }
            Console.WriteLine("Числото е: " + (factoriel2N / (factorielN * factorielN1)));

        }
    }
}

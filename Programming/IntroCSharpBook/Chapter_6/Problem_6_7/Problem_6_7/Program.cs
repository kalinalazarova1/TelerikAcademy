using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int factorielN = 1, factorielK = 1, factorielN_K = 1;
            Console.WriteLine("Моля въведете N:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Моля въведете К, за което K < N:");
            int k = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                factorielN = factorielN * i;
                if (i == k)
                {
                    factorielK = factorielN;
                }
                if (i == (n - k))
                {
                    factorielN_K = factorielN;
                }
            }
            
            Console.WriteLine("N!*K!/(N-K)!=" + (factorielN * factorielK / factorielN_K));
        }
    }
}

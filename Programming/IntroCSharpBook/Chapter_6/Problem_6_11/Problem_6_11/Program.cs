using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Моля въведете число:");
            int n = Int32.Parse(Console.ReadLine());
            int zeroNumber = 0;
            int fivePower = 5;
            while(fivePower <= n)
            {
                zeroNumber = zeroNumber + n / fivePower;
                fivePower = fivePower * 5;
            }
            Console.WriteLine("Броя на нулите в края на факториела са: " + zeroNumber);
        }
    }
}

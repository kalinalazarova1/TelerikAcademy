using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyNumbers
{
    class LuckyNumbers
    {
        static void Main(string[] args)
        {
            for (int i = 1000; i < 10000; i++)
            {
                if (((i / 1000) + (i - (i / 1000) * 1000) / 100) == (i - ((i / 1000) * 1000) - (((i - (i / 1000) * 1000) / 100) * 100)) / 10 + (i - ((i / 1000) * 1000) - (((i - (i / 1000) * 1000) / 100) * 100)) % 10)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

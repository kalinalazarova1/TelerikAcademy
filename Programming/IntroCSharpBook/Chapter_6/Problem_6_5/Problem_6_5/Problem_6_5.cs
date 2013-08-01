using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Problem_6_5
    {
        static void Main(string[] args)
        {
            int fibonachiFirst = 0, fibonachiSecond = 1, fibonachiCurrent;
            Console.WriteLine("Моля въведете броя на членовете от редицата на Фибоначи:");
            int num = int.Parse(Console.ReadLine());
            Console.Write(fibonachiFirst + ", " + fibonachiSecond + ", ");
            for (int i = 3; i <= num; i++)
            {
                fibonachiCurrent = fibonachiFirst + fibonachiSecond;
                fibonachiFirst = fibonachiSecond;
                fibonachiSecond = fibonachiCurrent;
                Console.Write(fibonachiCurrent + ", ");
            }
        }
    }
}

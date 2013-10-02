//6. Write a program that prints from given array of integers all numbers that are divisible by
//7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ArrayIntegers
{
    class ArrayIntegers
    {
        static void Main()
        {
            int[] test = new int[25];
            Random ran = new Random();
            for (int i = 0; i < 25; i++)
            {
                test[i] = ran.Next(1, 1001);
                Console.Write("{0} ",test[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Divisible by 3 and 7 at the same time:");
            foreach (var item in test.Where(n => n % 3 == 0 && n % 7 == 0))
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.WriteLine("Divisible by 3 and 7 at the same time with LINQ:");
            var divisibleByThreeAndSeven =
                from number in test
                where number % 3 == 0 && number % 7 == 0
                select number;
            foreach (var number in divisibleByThreeAndSeven)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }
    }
}

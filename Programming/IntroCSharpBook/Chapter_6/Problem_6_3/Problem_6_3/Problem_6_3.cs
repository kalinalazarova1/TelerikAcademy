using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_3
{
    class Problem_6_3
    {
        static void Main(string[] args)
        {
            int min, max;
            Console.WriteLine("Моля въведете броя на числата за сравнение:");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Моля въведете числата за сравнение:");
            int current = min = max = int.Parse(Console.ReadLine());
            for (int i = 1; i < num; i++)
            {
                current = int.Parse(Console.ReadLine());
                if (current > max)
                {
                    max = current;
                }
                if (current < min)
                {
                    min = current;
                }
            }
            Console.WriteLine("Най-малкото число е:" + min);
            Console.WriteLine("Най-голямото число е:" + max);
        }
    }
}

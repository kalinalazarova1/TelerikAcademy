//7. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
//Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
//2 -> 2 times
//3 -> 4 times
//4 -> 3 times

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //int[] arr = { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        int[] arr = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
        var occurences = arr.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());
        foreach (var item in occurences.OrderBy(x => x.Key))
        {
            Console.WriteLine("{0} -> {1} {2}", item.Key, item.Value, item.Value == 1 ? "time" : "times");
        }
    }
}

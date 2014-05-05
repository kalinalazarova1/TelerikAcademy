// 1. Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
// -2.5 -> 2 times
// 3 -> 4 times
// 4 -> 3 times

using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    internal static void Main()
    {
        double[] arr = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
        var result = new Dictionary<double, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (result.ContainsKey(arr[i]))
            {
                result[arr[i]]++;
            }
            else
            {
                result[arr[i]] = 1;
            }
        }

        foreach (var item in result.OrderBy(x => x.Key))
        {
            Console.WriteLine("{0} -> {1} {2}", item.Key, item.Value, item.Value == 1 ? "time" : "times");
        }
    }
}

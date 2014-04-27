//8.* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
//Write a program to find the majorant of given array (if exists).
//Example:
//{2, 2, 3, 3, 2, 3, 4, 3, 3}  3

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
        //int[] arr = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
        var occurences = arr.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());
        foreach (var item in occurences)
        {
            if (item.Value >= arr.Length / 2 + 1)
            {
                Console.WriteLine("Majorant: {0}", item.Key);
                return;
            }
        }
        Console.WriteLine("No majorant!");
    }
}

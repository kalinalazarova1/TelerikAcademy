//6. Write a program that removes from given sequence all numbers that occur odd number of times.
//Example:
//{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        var occurences = arr.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());
        for (int i = 0; i < arr.Length; i++)
        {
            if(occurences.ContainsKey(arr[i]) && occurences[arr[i]] % 2 == 0)
                Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
    }
}

// 2.Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:
// {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}

using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    internal static void Main()
    {
        string[] arr = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        var result = new Dictionary<string, int>();

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

        foreach (var item in result.Where(x => x.Value % 2 == 1))
        {
            Console.WriteLine("{0} -> {1} {2}", item.Key, item.Value, item.Value == 1 ? "time" : "times");
        }
    }
}

//5. Write a program that removes from given sequence all negative numbers.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = { 2, 3, 4, 5, -1, -11, 0, 17 , -23};
        var modifiedArray = arr.Where(x => x >= 0);
        foreach (var item in modifiedArray)
        {
            Console.WriteLine(item);
        }
    }
}

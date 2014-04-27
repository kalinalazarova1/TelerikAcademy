//3. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.

using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        var list = new List<int>();

        Console.WriteLine("Please input a sequence of integers ending with empty line:");
        try
        {
            for (string input = Console.ReadLine(); input != string.Empty; input = Console.ReadLine())
            {
                list.Add(int.Parse(input));
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine("The input number was not in the correct format.");
        }
        list.Sort();
        Console.WriteLine("The sorted sequence is: ");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}

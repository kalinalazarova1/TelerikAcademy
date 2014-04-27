//1. Write a program that reads from the console a sequence of positive integer numbers. 
//The sequence ends when empty line is entered. Calculate and print the sum and average 
//of the elements of the sequence. Keep the sequence in List<int>.

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
        catch(System.FormatException)
        {
            Console.WriteLine("The input number was not in the correct format.");
        }
        Console.WriteLine("The sum of the sequence is: {0}", list.Sum());
        Console.WriteLine("The average of the sequence is: {0}", list.Average());
    }
}

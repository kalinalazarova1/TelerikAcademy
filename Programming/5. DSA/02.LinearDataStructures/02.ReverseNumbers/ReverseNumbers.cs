//2. Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var stack = new Stack<int>();

        Console.WriteLine("Please input a sequence of integers ending with empty line:");
        try
        {
            for (string input = Console.ReadLine(); input != string.Empty; input = Console.ReadLine())
            {
                stack.Push(int.Parse(input));
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine("The input number was not in the correct format.");
        }
        Console.WriteLine("The reversed sequence is: ");
        while(stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}

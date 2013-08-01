//6. Write a program that reads from the console a string of maximum 20 characters.
//If the length of the string is less than 20, the rest of the characters should 
//be filled with '*'. Print the result string into the console.

using System;
using System.Text;

class PadRightString
{
    static void Main()
    {
        Console.WriteLine("Please input a string with maximal length of 20 characters:");
        string input = Console.ReadLine();
        if (input.Length > 20)
        {
            input = input.Remove(20);
        }
        Console.WriteLine(input.PadRight(20,'*'));
    }
}

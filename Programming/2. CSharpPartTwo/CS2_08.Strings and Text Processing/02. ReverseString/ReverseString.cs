//1. Write a program that reads a string, reverses it and prints the result at the console.

using System;

class ReverseString
{
    static void Main()
    {
        string input = "sample";
        char[] letters = input.ToCharArray();
        Array.Reverse(letters);
        Console.WriteLine(letters);
    }
}

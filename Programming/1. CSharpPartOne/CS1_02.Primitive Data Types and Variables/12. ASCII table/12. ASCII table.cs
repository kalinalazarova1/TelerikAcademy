//Write a program that prints the entire ASCII table of characters on the console

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("ASCII table:");
        for (short i = 0; i <= 127; i++)
            Console.WriteLine("symbol:{0} code:{1} ", (char)i, i);
    }
}

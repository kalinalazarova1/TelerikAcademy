//1. Write a method that asks the user for his name and prints "Hello, <name>" (for example: "Hello, Peter!").
//Write a program to test this method.

using System;

class Hello
{
    static void PrintHello()
    {
        Console.WriteLine("Please enter your name:");
        string userName = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", userName);
    }

    static void Main()
    {
        PrintHello();
    }
}

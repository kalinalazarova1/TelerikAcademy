using System;

class Problem_9_1
{
    static void PrintGreeting(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
        return;
    }
    static void Main()
    {
        Console.WriteLine("Please enter your name:");
        string yourName = Console.ReadLine();
        PrintGreeting(yourName);
    }
}

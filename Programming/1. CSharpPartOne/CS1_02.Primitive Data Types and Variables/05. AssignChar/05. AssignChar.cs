//Declare a character variable and assign it with a symbol that has Unicode code 72

using System;

class Program
{
    static void Main()
    {
        char symbol = '\u0048';
        Console.WriteLine("The symbol with Unicode {0} is: {1}", (int)symbol, symbol);
    }
}

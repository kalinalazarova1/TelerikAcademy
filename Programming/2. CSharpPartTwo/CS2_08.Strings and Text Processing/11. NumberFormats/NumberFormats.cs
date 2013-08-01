//11. Write a program that reads a number and prints it as a decimal number, hexadecimal number,
//percentage and in scientific notation. Format the output aligned right in 15 symbols.

using System;

class NumberFormats
{
    static void Main()
    {
        double input = double.Parse(Console.ReadLine());
        Console.WriteLine("{0,15:d}", (int)input);
        Console.WriteLine("{0,15:x}", (int)input);
        Console.WriteLine("{0,15:e}", input);
        Console.WriteLine("{0,15:p}", input);
    }
}

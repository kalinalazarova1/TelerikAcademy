//Write a program that prints a isosceles triangle of 9 copywrite symbols ©

using System;
using System.Text;

class Triangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        char symbol = '\u00A9';
        int symbolCount = 9;
        for (int i = 1; i <= symbolCount / 2 + 1; i += 2)
            Console.WriteLine("{1}{0}{1}", new string(symbol, i), new string(' ', (symbolCount / 2 + 1 - i) / 2));
    }
}

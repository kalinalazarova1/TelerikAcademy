//3. Write a program to convert decimal numbers to their hexadecimal representation.

using System;

class DecimalToHex
{
    /*static void Main()            //this is alternative solution of the problem;
    {
        Console.WriteLine("Please input decimal number:");
        Console.WriteLine(Convert.ToString(Int32.Parse(Console.ReadLine()), 16).ToUpper());
    }*/

    static void Main()
    {
        int decNumber;
        int[] hex = new int[32];
        int i;
        Console.WriteLine("Please input decimal number:");
        decNumber = Int32.Parse(Console.ReadLine());
        Console.Write("The hexadecimal equivalent of {0} is: ", decNumber);
        for (i = 0; decNumber > 0; i++)
        {
            hex[i] = decNumber % 16;
            decNumber /= 16;
        }
        while (i > 0)
        {
            i--;
            switch (hex[i])
            {
                case 10: Console.Write("A"); break;
                case 11: Console.Write("B"); break;
                case 12: Console.Write("C"); break;
                case 13: Console.Write("D"); break;
                case 14: Console.Write("E"); break;
                case 15: Console.Write("F"); break;
                default: Console.Write(hex[i]); break;
            }
        }
        Console.WriteLine();

    }
}

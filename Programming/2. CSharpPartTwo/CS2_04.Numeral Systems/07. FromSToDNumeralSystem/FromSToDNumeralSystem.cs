//7. Write a program to convert from any numeral system of given base s to any other numeral
//system of base d (2 <= s, d <= 16)

using System;
using System.Text;

class FromSToDNumeralSystem
{
    static void Main()
    {
        byte inBase, outBase;
        char[] digits = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F' };
        do
        {
            Console.WriteLine("Please enter the input numeral system base between 2 and 16 included:");
            inBase = byte.Parse(Console.ReadLine());
        }
        while (inBase < 2 || inBase > 16);
        Console.WriteLine("Please input a number:");
        string num = Console.ReadLine();
        do
        {
            Console.WriteLine("Please enter the output numeral system base between 2 and 16 included:");
            outBase = byte.Parse(Console.ReadLine());
        }
        while (outBase < 2 || outBase > 16);
        long decNumber = 0;
        for (int i = 0; i < num.Length; i++)
        {
            decNumber += Array.IndexOf(digits, num[i]) * (long)Math.Pow(inBase, num.Length - 1 - i);
        }
        StringBuilder outNumber = new StringBuilder();
        for (;decNumber > 0; decNumber /= outBase)
        {
            outNumber.Insert(0, digits[decNumber % outBase]);
        }
        Console.WriteLine(outNumber);
    }
}

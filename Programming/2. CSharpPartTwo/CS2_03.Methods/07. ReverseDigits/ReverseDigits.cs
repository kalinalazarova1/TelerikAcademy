//7. Write a method that reverses the digits of given decimal number. Example: 256 -> 652

using System;
using System.Text;

class _ReverseDigits
{
    static int ReverseDigits(int number)
    {
        StringBuilder reverseDigit = new StringBuilder(number.ToString().Length);
        for (int i = number.ToString().Length - 1; i >= 0 ; i--)
			{
			    reverseDigit.Append(number.ToString()[i]);   
			}
        return int.Parse(reverseDigit.ToString());
    }

    static void Main()
    {
        Console.WriteLine("Please input integer number:");
        int testNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("The reversed number is: {0}", ReverseDigits(testNumber));
    }
}

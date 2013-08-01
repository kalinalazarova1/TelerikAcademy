 //2. Write a method ReadNumber(int start, int end) that enters an integer number in given range
 //[start…end]. If an invalid number or non-number text is entered, the method should throw an 
 //exception. Using this method write a program that enters 10 numbers:
 // a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;
using System.Linq;

class _ReadNumber
{
    static int ReadNumber(int start, int end)
    {
        Console.WriteLine("Please enter number between {0} and {1} including", start, end);
        int number = int.Parse(Console.ReadLine());
        if (number > end || number < start)
        {
            throw new FormatException(String.Format("Invalid number - must be between {0} and {1} including", start, end));
        }
        return number;
    }

    static void Main()
    {
        int[] numbers = new int[11];
        numbers[0] = 1;
        try
        {
            for (int i = 0; i < 10; i++)
            {
                numbers[i + 1] = ReadNumber(numbers[i], 100);
            }
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

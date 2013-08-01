//Write a program that reads from the console a sequence of N integer numbers and then
//returns the minimal and the maximal of them.

using System;

class MinMaxInteger
{
    static void Main()
    {
        int minNumber = int.MaxValue;
        int maxNumber = int.MinValue;
        uint count;
        bool isValid;
        int number;
        do
        {
            Console.WriteLine("Please input the count of the numbers N:");
            isValid = uint.TryParse(Console.ReadLine(), out count);
        }
        while (!isValid || count == 0);
        for (int i = 0; i < count; i++)
        {
            do
            {
                Console.WriteLine("Please input a number {0} for comparison", i + 1);
                isValid = Int32.TryParse(Console.ReadLine(), out number);
            }
            while (!isValid);
            if (number > maxNumber) maxNumber = number;
            if (number < minNumber) minNumber = number;
        }
        Console.WriteLine("The minimal number is: {0} and the maximal number is: {1}", minNumber, maxNumber);
    }
}

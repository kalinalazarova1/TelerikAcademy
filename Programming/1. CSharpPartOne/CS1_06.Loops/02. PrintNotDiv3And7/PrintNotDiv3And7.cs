//Write a program that prints all the numbers from 1 to N which are not divisible by 3 and
// 7 at the same time.

using System;

class PrintNotDiv3And7
{
    static void Main()
    {
        uint number;
        bool isValid;
        do
        {
            Console.WriteLine("Please input integer number N:");
            isValid = uint.TryParse(Console.ReadLine(), out number);
        }
        while (!isValid);
        Console.WriteLine("The numbers from 1 to {0} which are not divisible by 3 and 7 are: ", number);
        for (int i = 1; i <= number; i++)
        {
            if((i % 3 + i % 7) != 0)    Console.Write("{0} ", i);
        }
    }
}

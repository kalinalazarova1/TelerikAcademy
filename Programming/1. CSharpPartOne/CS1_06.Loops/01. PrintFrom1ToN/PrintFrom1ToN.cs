//Write a program that prints all the numbers from 1 to N

using System;

class PrintFrom1ToN
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
        Console.WriteLine("The numbers from 1 to {0} are: ", number);
        for (int i = 0; i < number; i++)
        {
            Console.Write("{0} ", i + 1);
        }
    }
}

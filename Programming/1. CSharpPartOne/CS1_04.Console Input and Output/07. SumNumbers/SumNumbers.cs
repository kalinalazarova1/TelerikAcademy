//Write a program that gets number n and then gets more n numbers and calculates and prints their sum.

using System;

class SumNumbers
{
    static void Main()
    {
        uint numberCount;
        double sum = 0;
        double number;
        do
        {
            Console.WriteLine("Please input the count of the numbers to sum:");
        }
        while (!uint.TryParse(Console.ReadLine(), out numberCount));
        for(int i = 0; i < numberCount; i++)
        {
            do
            {
                Console.WriteLine("Please enter number {0}: ", i + 1);
            }
            while(!double.TryParse(Console.ReadLine(), out number));
            sum += number;
        }
        Console.WriteLine("The sum of the numbers is: {0}", sum);
    }
}

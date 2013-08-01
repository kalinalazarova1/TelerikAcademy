//Write a program that reads an integer number n from the console and prints all the numbers
//in the interval [1, n], each on a single line.

using System;

class AllNumbers1N
{
    static void Main()
    {
        uint numberCount;
        do
        {
            Console.WriteLine("Please input the end number of the interval (integer greater than 0) :");
        }
        while (!uint.TryParse(Console.ReadLine(), out numberCount));
        Console.WriteLine("All the numbers in the interval [1,n] are:");
        for (int i = 0; i < numberCount; i++)
        {
            Console.WriteLine(i + 1);
        }
    }
}

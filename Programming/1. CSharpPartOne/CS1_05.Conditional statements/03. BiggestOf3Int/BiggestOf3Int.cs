//Write a program that finds the biggest of three integer numbers using nested if statements.

using System;

class BiggestOf3Int
{
    static void Main()
    {
        int firstInt, secondInt, thirdInt, maxInt;
        bool isValid;
        do
        {
            Console.WriteLine("Please enter the first integer number:");
            isValid = Int32.TryParse(Console.ReadLine(), out firstInt);
        }
        while (!isValid);
        do
        {
            Console.WriteLine("Please enter the second integer number:");
            isValid = Int32.TryParse(Console.ReadLine(), out secondInt);
        }
        while (!isValid);
        do
        {
            Console.WriteLine("Please enter the third integer number:");
            isValid = Int32.TryParse(Console.ReadLine(), out thirdInt);
        }
        while (!isValid);
        if (firstInt > secondInt)
        {
            if (firstInt > thirdInt)
            {
                maxInt = firstInt;
            }
            else
            {
                maxInt = thirdInt;
            }
        }
        else
        {
            if (secondInt > thirdInt)
            {
                maxInt = secondInt;
            }
            else
            {
                maxInt = thirdInt;
            }
        }
        Console.WriteLine("The biggest number is: {0}", maxInt);
    }
}

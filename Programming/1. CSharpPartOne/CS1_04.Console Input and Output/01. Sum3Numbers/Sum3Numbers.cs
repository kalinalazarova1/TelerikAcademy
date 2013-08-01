//Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class Sum3Numbers
{
    static void Main()
    {
        int firstNum;
        int secondNum;
        int thirdNum;
        bool isValid;
        do
        {
            Console.WriteLine("Please input the first integer number:");
            isValid = Int32.TryParse(Console.ReadLine(), out firstNum);
        }
        while(!isValid);
        do
        {
            Console.WriteLine("Please input the second integer number:");
            isValid = Int32.TryParse(Console.ReadLine(), out secondNum);
        }
        while(!isValid);
        do
        {
            Console.WriteLine("Please input the third integer number:");
            isValid = Int32.TryParse(Console.ReadLine(), out thirdNum);
        }
        while (!isValid);
        Console.WriteLine("The sum of the three numbers is: {0}", firstNum + secondNum + thirdNum);
    }
}

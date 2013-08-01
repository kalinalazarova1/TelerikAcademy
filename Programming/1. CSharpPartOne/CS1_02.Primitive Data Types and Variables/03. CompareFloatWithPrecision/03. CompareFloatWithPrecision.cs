//Write a program that safely compares floating-point numbers with a precision of 0.000001

using System;

class CompareFloatWithPrecision
{
    static void Main()
    {
        decimal firstNum, secondNum;
        Console.WriteLine("Please enter the first number:");
        firstNum = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        secondNum = decimal.Parse(Console.ReadLine());
        Console.WriteLine (Math.Abs(firstNum - secondNum) < 0.000001m);
    }
}

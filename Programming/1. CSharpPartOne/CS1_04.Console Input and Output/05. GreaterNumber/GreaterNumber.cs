//Write a program that reads two positive numbers from the console and prints the greater of them. Do not use if statement.

using System;

class GreaterNumber
{
    static void Main()
    {
        double firstNum, secondNum;
        bool isValid;
            do
            {
                Console.WriteLine("Please input the first positive number:");
                isValid = double.TryParse(Console.ReadLine(), out firstNum);
            }
            while (!isValid || firstNum <= 0);
            do
            {
                Console.WriteLine("Please input the second positive number:");
                isValid = double.TryParse(Console.ReadLine(), out secondNum);
            }
            while (!isValid || secondNum <= 0);
        double maxNum = (firstNum + secondNum + Math.Abs(firstNum - secondNum)) / 2;
        Console.WriteLine("The greater number is: {0}", maxNum);
    }
}

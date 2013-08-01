//Write a program that calculatess the greatest common divisor (GCD) of given two numbers.
//Use the Euclidean algorithm (find it in Internet).

using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        int firstNum = 2142;
        int secondNum = 522;
        int temp;
        if (firstNum < secondNum)
        {
            temp = firstNum;
            firstNum = secondNum;
            secondNum = temp;
        }
        while (firstNum % secondNum != 0)
        {
            temp = secondNum;
            secondNum = firstNum % secondNum;
            firstNum = temp;
        }
        Console.WriteLine("The GCD is: {0}", secondNum);
    }
}

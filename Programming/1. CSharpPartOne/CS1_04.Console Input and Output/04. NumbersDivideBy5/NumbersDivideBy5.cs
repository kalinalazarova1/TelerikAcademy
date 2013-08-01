//Write a program that reads two positive integer numbers from the console and prints how many numbers p exist between
//them such that the remainder of the division by 5 is zero (inclusive). Example: p(17, 25) = 2.

using System;

class NumbersDivideBy5
{
    static void Main()
    {
        uint startNum, endNum;
        int numberCount = 0;
        bool isValid;
        do
        {
            Console.WriteLine("Please enter the starting number of the interval, greater than 0:");
            isValid = UInt32.TryParse(Console.ReadLine(), out startNum);
        }
        while(!isValid || startNum <= 0);
        do
        {
            Console.WriteLine("Please enter greater number for the end of the interval, greater than 0:");
            isValid = UInt32.TryParse(Console.ReadLine(), out endNum);
        }
        while (startNum > endNum || !isValid );
        for (uint i = startNum; i <= endNum; i++)
        {
            if (i % 5 == 0)
                numberCount++;
        }
        Console.WriteLine("There are {0} numbers in the interval ({1}, {2}) which divided by 5 have a zero remainder.", numberCount, startNum, endNum);
    }
}

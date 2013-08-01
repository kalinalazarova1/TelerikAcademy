//Write a program that reads a number N and calculates the sum of the first N members of the
//sequence of Fibonacci:0, 1, 1, 2, 3, 5, 8... Each member of the Fibonacci sequence (except for the first two) is a sum of the previous two numbers.

using System;

class FibonacciSequence
{
    static void Main()
    {
        uint fibCurrent;
        uint fibPrevious = 0;
        uint fibPrePrevious = 1;
        ulong sum = 0;
        uint count;
        bool isValid;
        do
        {
        Console.WriteLine("Please input the count of the members of the sequence of Fibonacci:");
        isValid = uint.TryParse(Console.ReadLine(), out count);
        }
        while(!isValid);
        for (int i = 1; i <= count; i++)
        {
            sum += fibPrePrevious;
            fibCurrent = fibPrePrevious + fibPrevious;
            fibPrePrevious = fibPrevious;
            fibPrevious = fibCurrent;
        }
        Console.WriteLine("The sum of the first {0} members of the Fibonacci sequence is: {1}", count, sum);
    }
}

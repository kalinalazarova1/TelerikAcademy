//13. Write a program that can solve these tasks:
// - Reverses the digits of a number;
// - Calculates the average of a sequence of integers;
// - Solves a linear equation ax + b = 0;
// Creates appropriate methods.
// Provide a simple text-based menu for the user to choose which task to solve.
// Validate the input data:
// - The decimal number should be non-negative;
// - The sequence should not be empty;
// - a should not be equal to 0;

using System;

class VariousActions
{
    static void PrintReverseNumber(int num)
    {
        for (num = Math.Abs(num); num != 0; num /= 10)
        {
            Console.Write(num % 10);
        }
        Console.WriteLine();
    }

    static double CalcArithmeticAverage(double[] arr)
    {
        double sum = 0.0;
        if (arr.GetLength(0) == 0)
        {
            return 0.0f;
        }
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            sum += arr[i];
        }
        return sum / arr.GetLength(0);
    }

    static double CalcLinearEquation(double a, double b)
    {
        if (a == 0)
        {
            return double.PositiveInfinity;
        }
        double x = -b / a;
        return x;
    }

    static void Main()
    {
        Console.WriteLine("Please choose: 1 - reversion, 2 - average, 3 - equation");
        int choice = Int32.Parse(Console.ReadLine());
        int decimalNumber = 0;
        double firstParam, secondParam;
        switch (choice)
        {
            case 1:
                do
                {
                    Console.WriteLine("Please enter positive number for inversion:");
                    decimalNumber = Int32.Parse(Console.ReadLine());
                }
                while (decimalNumber < 0);
                PrintReverseNumber(decimalNumber);
                break;
            case 2:
                do
                {
                    Console.WriteLine("Please enter the count of the numbers:");
                    decimalNumber = Int32.Parse(Console.ReadLine());
                }
                while (decimalNumber == 0);
                double[] numbers = new double[decimalNumber];
                for (int i = 0; i < decimalNumber; i++)
                {
                    Console.WriteLine("Please enter number:");
                    numbers[i] = Double.Parse(Console.ReadLine());
                }
                Console.WriteLine("The arithmetic average is: {0}", CalcArithmeticAverage(numbers));
                break;
            case 3:
                do
                {
                    Console.WriteLine("Please enter the value for a:");
                    firstParam = Double.Parse(Console.ReadLine());
                }
                while (firstParam == 0);
                Console.WriteLine("Please enter the value for b:");
                secondParam = Double.Parse(Console.ReadLine());
                Console.WriteLine("For ax + b = 0, x is {0}", CalcLinearEquation(firstParam, secondParam));
                break;
            default:
                Console.WriteLine("Wrong choice!");
                break;
        }
    }
}

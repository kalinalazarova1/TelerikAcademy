//Write a program that finds the greatest of given 5 variables.

using System;

class Max5Variables
{
    static void Main()
    {
        double[] numbers = new double[5];
        double maxNumber = double.MinValue;
        bool isValid;
        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            do
            {
                Console.WriteLine("Please input number {0}:", i + 1);
                isValid = double.TryParse(Console.ReadLine(), out numbers[i]);
            }
            while (!isValid);
            if (numbers[i] > maxNumber)
            {
                maxNumber = numbers[i];
            }
        }
        Console.WriteLine("The greatest number is: {0}", maxNumber);
    }
}

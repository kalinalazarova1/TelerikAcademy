//Write a program that calculates the sum 1+1/2-1/3+1/4-1/5...with the accuracy of 0.001 

using System;

class SumWithAccuracy
    {
        static void Main()
        {
            double sum = 1;
            for (int i = 2; Math.Abs(1 / (Math.Pow(-1, i) * i)) >= 0.001; i++)
            {
                sum += 1 / (Math.Pow(-1, i) * i);
            }
            Console.WriteLine("The sum 1+1/2-1/3+1/4-1/5...with accuracy 0.001 is: {0: 0.000}", sum);
        }
    }

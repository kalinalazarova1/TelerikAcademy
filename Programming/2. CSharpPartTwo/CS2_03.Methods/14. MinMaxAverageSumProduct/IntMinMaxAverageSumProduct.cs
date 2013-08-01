//14. Write a methods to calculate minimum, maximum, sum, average and product of given set of integer
//numbers. Use variable number of arguments.

using System;

class IntMinMaxAverageSumProduct
{
    static int GetMax(params int[] num) 
    {
        int max = num[0];
        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] > max)
            {
                max = num[i];
            }
        }
        return max;
    }

    static int GetMin(params int[] num)
    {
        int min = num[0];
        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] < min)
            {
                min = num[i];
            }
        }
        return min;
    }

    static int GetSum(params int[] num)
    {
        int sum = 0;
        for (int i = 1; i < num.Length; i++)
        {
            sum += num[i];
        }
        return sum;
    }

    static long GetProduct(params int[] num)
    {
        long product = 1;
        for (int i = 0; i < num.Length; i++)
        {
            product *= num[i];
        }
        return product;
    }

    static double GetAverage(params int[] num)
    {
        return GetSum(num) / (double)num.Length;
    }

    static void Main()
    {
        Console.WriteLine("Minimal: {0}", GetMin(1, 5, 3, 4, 7, 8, 4));
        Console.WriteLine("Maximal: {0}", GetMax(1, 5, 3, 4));
        Console.WriteLine("Sum: {0}", GetSum(3, 5, 8, 7, 9, 12, 3, 5));
        Console.WriteLine("Average: {0}", GetAverage(3, 5, 8, 7, 9));
        Console.WriteLine("Product: {0}", GetProduct(3, 5, 8, 7));
    }
}

//15* Modify your last program and try to make it work with any number type, not just integer 
//(e.g. ecimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).

using System;
using System.Collections.Generic;

class MinMaxSumAverageProduct
{
    static T GetMax<T>(params T[] num)
    {
        dynamic max = num[0];
        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] > max)
            {
                max = num[i];
            }
        }
        return max;
    }

    static T GetMin<T>(params T[] num)
    {
        dynamic min = num[0];
        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] < min)
            {
                min = num[i];
            }
        }
        return min;
    }

    static T GetSum<T>(params T[] num)
    {
        dynamic sum = 0;
        for (int i = 1; i < num.Length; i++)
        {
            sum += num[i];
        }
        return sum;
    }

    static T GetProduct<T>(params T[] num)
    {
        dynamic product = 1;
        for (int i = 0; i < num.Length; i++)
        {
            product *= num[i];
        }
        return product;
    }

    static T GetAverage<T>(params T[] num)
    {
        return GetSum(num) / (dynamic)num.Length;
    }

    static void Main()
    {
        Console.WriteLine("Minimal: {0}", GetMin(1m, 5m, 3m, 4m, 7m, 8m, 4m));
        Console.WriteLine("Maximal: {0}", GetMax(1.345f, 5.33f, 3.14f, 14f));
        Console.WriteLine("Sum: {0}", GetSum(3, 5, 8, 7, 9, 12, 3, 5));
        Console.WriteLine("Average: {0}", GetAverage(3.0, 5.25, 8.70, 7.5, 9));
        Console.WriteLine("Product: {0}", GetProduct(3, 3, -8, 1));
    }
}

using System;

public class ArrayStatistics
{
    public static void PrintStatistics(double[] arr, int count)
    {
        Console.WriteLine("Statistics Report:");
        Console.WriteLine("------------------");
        Print("Maximum", Max(arr, count));
        Print("Minimum", Min(arr, count));
        Print("Average", Average(arr, count));
        Console.WriteLine("------------------");
    }

    public static double Max(double[] arr, int count)
    {
        double max = double.MinValue;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    public static double Min(double[] arr, int count)
    {
        double min = double.MaxValue;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    public static double Average(double[] arr, int count)
    {
        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += arr[i];
        }

        double average = sum / count;
        return average;
    }

    public static void Print(string meaning, double value)
    {
        Console.WriteLine("{0} : {1:0.00}", meaning, value);
    }

    public static void Main(string[] args)
    {
        double[] testArray = { 1.5, 12.7, 2, 3.1, -0.05, -12 };
        Console.WriteLine("Array: {0}", string.Join(", ", testArray));
        Console.WriteLine();
        PrintStatistics(testArray, testArray.Length);
    }
}

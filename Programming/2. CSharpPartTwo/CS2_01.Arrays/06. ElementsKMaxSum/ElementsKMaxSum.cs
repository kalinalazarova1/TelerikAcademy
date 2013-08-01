//  6. Write a program that reads two integer numbers N and K
//  and an array of N elements from the console. Find in the
//  array those K elements that have maximal sum.

using System;
using System.Linq;

class ElementsKMaxSum           //for K elements which are not consecutive;
{
    static void Main()
    {
        int maxSum = 0;
        Console.WriteLine("Please input the array size:");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Please input element {0} of the array:", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Please input elements count:");
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < k; i++)
        {
            maxSum += numbers.Max();
            numbers[Array.IndexOf(numbers, numbers.Max())] = int.MinValue;
        }
        Console.WriteLine("The maximal sum of {0} elements is: {1}", k, maxSum);
    }
}

//6.  Write a program that reads two integer numbers N and K
//  and an array of N elements from the console. Find in the
//  array those K elements that have maximal sum.

using System;

class ElementsKMaxSum_v2        //for K elements which are consecutive;
{
    static void Main()
    {
        int curSum = 0;
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
            curSum += numbers[i];
        }
        int maxSum = curSum;
        for (int i = 0; i < n - k; i++)
        {
            curSum = curSum - numbers[i] + numbers[i + k];
            if (curSum > maxSum)
            {
                maxSum = curSum;
            }
        }
        Console.WriteLine("The maximal sum of {0} elements is: {1}", k, maxSum);
    }
}

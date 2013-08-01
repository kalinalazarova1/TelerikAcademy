//4. Write a program that reads from the console an array of N integers and an integer K, sorts the array
//and using the method Array.BinarySearch() find the largest number in the array, which is <= K.

using System;

class LargestNumberInArray
{
    static void Main()
    {
        Console.WriteLine("Please input a number N:");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Please input element {0}:", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(numbers);
        Console.WriteLine("Please input an integer number k:");
        int k = int.Parse(Console.ReadLine());
        int index = Array.BinarySearch(numbers, k);
        if (index > 0)
        {
            Console.WriteLine(numbers[index]);
        }
        else if (index != -1)
        {
            Console.WriteLine(numbers[~index - 1]);
        }
        else
        {
            Console.WriteLine("There is no such number which is <= k in the array.");
        }
    }
}

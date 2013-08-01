//9. Write a program that finds the most frequent number in an array. Example:
//{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} 4 -> 5 times

using System;

class MaxEqualElements
{
    static void Main()
    {
        int currCount = 1;
        int maxCount = 0;
        int maxIndex = -1;
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        Array.Sort(arr);
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                currCount++;
                if (currCount > maxCount)
                {
                    maxCount = currCount;
                    maxIndex = i;
                }
            }
            else
            {
                currCount = 1;
            }
        }
        Console.WriteLine("The most frequent element in the array is {0} and is found {1} times.", arr[maxIndex], maxCount);
    }
}

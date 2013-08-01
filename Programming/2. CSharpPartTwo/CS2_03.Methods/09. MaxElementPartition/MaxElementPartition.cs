//9. Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending/ descending order.

using System;

class MaxElementPartition
{
    static int GetMaxElementPartition(int[] arr, int startIndex, int endIndex)
    {
        if (startIndex < 0 || endIndex > arr.Length - 1)
        {
            throw new IndexOutOfRangeException();
        }
        if (startIndex > endIndex)
        {
            throw new IndexOutOfRangeException("The start index of the array should be less or equal to end index.");
        }
        int maxIndex = startIndex;
        int max = arr[startIndex];
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i] > max)
            {
                maxIndex = i;
                max = arr[i];
            }
        }
        return maxIndex;
    }

    static void Swap(int[]arr, int firstIndex, int secondIndex)
    {
        int temp = arr[firstIndex];
        arr[firstIndex] = arr[secondIndex];
        arr[secondIndex] = temp;
    }

    static int[] SelectionSort(int[] arr, char c)
    {
        if (c == 'a')                   //ascending order;
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, i, GetMaxElementPartition(arr, 0, i));
            }
        }
        else                           //descending order (by default);
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Swap(arr, i, GetMaxElementPartition(arr, i, arr.Length - 1));
            }
        }
        return arr;
    }

    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i < arr.Length - 1)
            {
                Console.Write("{0}, ", arr[i]);
            }
            else
            {
                Console.WriteLine("{0}", arr[i]);
            }
        }
    }

    static void Main()
    {
        int[] arr = { 34, 56, 72, 12, 43, -10, -34, 0, 11, 7, 3, 18, 24 };
        Console.WriteLine("Unsorted array:");
        PrintArray(arr);
        Console.WriteLine("Sorted array ascending order:");
        PrintArray(SelectionSort(arr, 'a'));
        Console.WriteLine("Sorted array descending order:");
        PrintArray(SelectionSort(arr, 'd'));
    }
}

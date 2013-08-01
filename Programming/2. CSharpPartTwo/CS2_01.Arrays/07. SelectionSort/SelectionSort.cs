//  7. Sorting an array means to arrange its elements in increasing order.
//  Write a program to sort an array. Use the "selection sort" algorithm:
//  Find the smallest element, move it at the first position, find the
//  smallest from the rest, move it at the second position, etc.

using System;

class _SelectionSort
{
    static int[] SelectionSort(int[] arr)
    {
        int min, temp;
        for (int i = 0; i < arr.Length; i++)
        {
            min = i;
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
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
        Console.WriteLine("Sorted array:");
        PrintArray(SelectionSort(arr));
    }
}

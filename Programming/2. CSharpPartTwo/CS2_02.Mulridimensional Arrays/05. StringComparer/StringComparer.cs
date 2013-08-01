//You are given an array of strings. Write a method that sorts the array by 
//the length of its elements (the number of characters composing them).

using System;

class _StringComparer
{
    static string GetShorterString(string first, string second)
    {
        return first.Length < second.Length ? first : second;
    }

    static void QuickSort(string[] arr, int l, int r)
    {
        if (l < r)
        {
            int pivot = new Random().Next(l, r + 1);
            pivot = Partition(arr, l, r, pivot);
            QuickSort(arr, l, pivot - 1);
            QuickSort(arr, pivot + 1, r);
        }

    }

    static void Swap(string[] arr, int i, int j)
    {
        string temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static int Partition(string[] arr, int l, int r, int pivot)
    {
        string pivotValue = arr[pivot];
        Swap(arr, pivot, r);
        int j = l;
        for (int i = l; i < r; i++)
        {
            if (GetShorterString(arr[i], pivotValue) == arr[i])
            {
                Swap(arr, i, j++);
            }
        }
        Swap(arr, r, j);
        return j;
    }

    static void PrintArray(object[] arr)
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
        string[] arr = { "aba", "z", "ab", "a", "ababa", "ababababab", "xyz", "zzzz" };
        Console.WriteLine("Unsorted array:");
        PrintArray(arr);
        Console.WriteLine("Sorted array:");
        QuickSort(arr, 0, arr.Length - 1);
        PrintArray(arr);
    }

}

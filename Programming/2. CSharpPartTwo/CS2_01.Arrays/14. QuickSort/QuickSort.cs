//14.Write a program that sorts an array of strings
//using the quick sort algorithm (find it in Wikipedia).

using System;

class _QuickSort
{
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

    static string GetLexicographicallyFirst(string first, string second)
    {
        for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
        {
            if (first[i] < second[i])
            {
                return first;
            }
            else if(second[i] < first[i])
            {
                return second;
            }
        }
        return first.Length < second.Length ? first : second;
    }

    static int Partition(string[] arr, int l, int r, int pivot)
    {
        string pivotValue = arr[pivot];
        Swap(arr, pivot, r);
        int j = l;
        for (int i = l; i < r; i++)
        {
            if (GetLexicographicallyFirst(arr[i], pivotValue) == arr[i])
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
        string[] arr = { "mother","father","sister","brother","uncle","aunt","grandmother", "grandfather" };
        Console.WriteLine("Unsorted array:");
        PrintArray(arr);
        Console.WriteLine("Sorted array:");
        QuickSort(arr, 0, arr.Length - 1);
        PrintArray(arr);
    }
}

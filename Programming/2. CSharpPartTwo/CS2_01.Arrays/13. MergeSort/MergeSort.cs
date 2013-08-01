//13.* Write a program that sorts an array of integers using the merge 
//sort algorithm (find it in Wikipedia).

using System;

class _MergeSort
{
    static void MergeSort(int[] arr, int[] temp, int l, int r)
    {
        if (l >= r)
        {
            return;
        }
        int m = l + (r - l) / 2;        
        MergeSort(arr, temp, l, m);
        MergeSort(arr, temp, m + 1, r);
        Merge(arr, temp, l, m, r);
    }

    static void Merge(int[] arr, int[] temp, int l, int m, int r)
    {
        for (int i = l, left = l, right = m + 1; left <= m || right <= r; i++)
        {
            if (left > m)
            {
                temp[i] = arr[right++];
            }
            else if (right > r)
            {
                temp[i] = arr[left++];
            }
            else if (arr[left] <= arr[right])
            {
                temp[i] = arr[left++];
            }
            else if (arr[left] > arr[right])
            {
                temp[i] = arr[right++];
            }
        }
        for (int i = l; i <= r; i++)
        {
            arr[i] = temp[i];
        }
        return;
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
        int[] temp = new int[arr.Length];
        Console.WriteLine("Unsorted array:");
        PrintArray(arr);
        Console.WriteLine("Sorted array:");
        MergeSort(arr, temp, 0, arr.Length - 1);
        PrintArray(arr);
    }
}

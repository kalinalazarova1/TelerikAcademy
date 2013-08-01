using System;

class Problem_10_6
{
    static void MergeSort(int[] arr, int[] temp, int s, int e)
    {
        int m;
        if (s >= e)
            return;
        m = (s + e) / 2;
        MergeSort(arr, temp, s, m);
        MergeSort(arr, temp, m + 1, e);
        Merge(arr, temp, s, m, e);
    }

    static void Merge(int[] arr, int[] temp, int s, int m, int e)
    {
        int j = s;
        int k = m + 1;
        for (int i = s; i <= e; i++)
            if (k > e && j > m)
                return;
            else if (k > e)
                temp[i] = arr[j++];
            else if (j > m)
                temp[i] = arr[k++];
            else if (arr[j] > arr[k])
                temp[i] = arr[k++];
            else
                temp[i] = arr[j++];
        CopyArray(temp, arr, s, e);
    }

    static void CopyArray(int[] arr1, int[] arr2, int startIndex, int endIndex)
    {
        for (int i = startIndex; i <= endIndex; i++)
            arr2[i] = arr1[i];
    }

    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
            Console.Write("{0} ", arr[i]);
        Console.WriteLine();
    }
    static void Main()
    {
        int[] array = { 2, 5, 6, 3, 7, 4, 5, 6, 8, 7, 9, 3, 2 };
        int[] temp = new int[array.GetLength(0)];
        Console.Write("Unsorted array:");
        PrintArray(array);
        MergeSort(array, temp, 0, array.GetLength(0) - 1);
        Console.Write("Sorted array:");
        PrintArray(array);
    }
}

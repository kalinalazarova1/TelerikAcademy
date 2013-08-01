using System;

class Problem_9_9
{
    static int GetIndexMaxElement(int[] arr, int s, int e)
    {
        int maxIndex = s;
        for (int i = s + 1; i <= e; i++)
        {
            if (arr[i] > arr[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    static void SwapArrayElements (int[] arr, int firstIndex, int secondIndex)
    {
        int temp = arr[firstIndex];
        arr[firstIndex] = arr[secondIndex];
        arr[secondIndex] = temp;
    }

    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
    }

    static void SortArrayDescending(int[] arr)
    {
        for (int i = 0; i < arr.GetLength(0) - 1; i++)
        {
            SwapArrayElements(arr, i, GetIndexMaxElement(arr, i + 1, arr.GetLength(0) - 1));
        }
    }

    static void SortArrayAscending(int[] arr)
    {
        for (int i = arr.GetLength(0) - 1; i > 0; i--)
        {
            SwapArrayElements(arr, i, GetIndexMaxElement(arr, 0, i));
        }
    }

    static void Main()
    {
        int[] startArray = {2, 4, 3, 6, 2, 7, 9, 8, 1, 2, 5};
        PrintArray(startArray);
        SortArrayDescending(startArray);
        PrintArray(startArray);
        SortArrayAscending(startArray);
        PrintArray(startArray);
    }
}

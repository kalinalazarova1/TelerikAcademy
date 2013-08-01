// 11. Write a program that finds the index of
// given element in a sorted array of integers
// by using the binary search algorithm (find it in Wikipedia).

using System;

class _BinarySearch
{
    static void Main()
    {
        int value = 52;
        int[] arr = {23, 43, 45, 46, 49, 50, 52, 57, 63, 74, 88, 97};
        int r = arr.Length - 1;
        for (int l = 0; l < r;)
        {
            int m = (l + r) / 2;
            if (arr[m] < value)
            {
                l = m + 1;
            }
            else if (arr[m] > value)
            {
                r = m - 1;
            }
            else
            {
                Console.WriteLine("The index of the element is: {0}", m);
                return;
            }
        }
        Console.WriteLine("There is no such element in the array.");
    }

   /* static void BinarySearch(int[] arr, int l, int r, int v)
    {
        int m = (l + r) / 2;
        if (l >= r)
        {
            return;
        }
        if (arr[m] < v)
        {
            BinarySearch(arr, m + 1, r, v);
        }
        else if (arr[m] > v)
        {
            BinarySearch(arr, l, m - 1, v);
        }
        else
        {
            Console.WriteLine(m);
            return;
        }
    }

    static void Main()
    {
        int value = 52;
        int[] arr = { 23, 43, 45, 46, 49, 50, 52, 57, 63, 74, 88, 97 };
        int right = arr.Length - 1;
        int left = 0;
        BinarySearch(arr, left, right, value);
    }*/
}

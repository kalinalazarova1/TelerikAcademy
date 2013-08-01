using System;

class Problem_9_5
{
    static int GetMax(int a, int b)
    {
        if (a >= b)
            return a;
        else
            return b;
    }
    static int GetMin(int a, int b)
    {
        if (a <= b)
            return a;
        else
            return b;
    }
    static int CompareElement(int[] arr, int i)
    {
        if (i < arr.GetLength(0) - 1 && i > 0)
        {
            if (arr[i] == GetMax(arr[i], GetMax(arr[i - 1], arr[i + 1])))
                return 1;
            else if (arr[i] == GetMin(arr[i], GetMin(arr[i - 1], arr[i + 1])))
                return -1;
            else
                return 0;
        }
        else if (i == arr.GetLength(0) - 1)
        {
            if (arr[i] > arr[i - 1])
                return 1;
            else
                return -1;
        }
        else if (i == 0)
        {
            if (arr[i] > arr[i + 1])
                return 1;
            else
                return -1;
        }
        else
            return 2;
    }

    static void Main()
    {
        int[] arr = { 1, 4, 6, 8, 3, 7, 8, 9, 4, 5, 7, 6, 8 };
        int index;
        Console.WriteLine("Please input the index of the element for comparison:");
        index = Int32.Parse(Console.ReadLine());
        switch(CompareElement(arr, index))
        {
            case -1: Console.WriteLine("Element {0} of the array is minimal.", index); break;
            case 0: Console.WriteLine("Element {0} of the array is between the neighbouring elements.", index); break;
            case 1: Console.WriteLine("Element {0} of the array is maximal", index); break;
            case 2: Console.WriteLine("Index {0} outside the boundaries of the array", index); break;
        }
    }
}

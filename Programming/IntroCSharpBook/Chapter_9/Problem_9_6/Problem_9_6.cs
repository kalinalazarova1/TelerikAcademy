using System;

class Problem_9_6
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
    static int GetFirstMaxElem(int[] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            if (CompareElement(arr, i) == 1)
                return i;
        }
        return -1;
    }

    static void Main()
    {
        int[] arr = { 1, 4, 6, 8, 13, 17, 18, 19, 24, 25, 27, 36, 36 };
        if (GetFirstMaxElem(arr) != -1)
        {
            Console.WriteLine("The first maximal element is {0} on position {1} of the array.", arr[GetFirstMaxElem(arr)], GetFirstMaxElem(arr));
        }
        else
        {
            Console.WriteLine("There is no maximal element in the array.");
        }
    }
}

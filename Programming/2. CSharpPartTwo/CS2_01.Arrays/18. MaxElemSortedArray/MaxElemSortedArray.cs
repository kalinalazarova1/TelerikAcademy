//18.* Write a program that reads an array of integers and removes from it a minimal number
//of elements in such way that the remaining array is sorted in increasing order. Print the
//remaining sorted array. Example:
//    {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}

using System;

class MaxElemSortedArray
{
    static bool IsSorted(int[] num, ulong index)
    {
        int i = 0;
        while (((index >> i) & 1) == 0 && i < 64)
        {
            i++;
        }
        int prevNum = num[i];
        for (i++; i < num.Length; i++)
        {
            if (((index >> i) & 1) == 1)
            {
                if (prevNum > num[i])
                {
                    return false;
                }
                prevNum = num[i];
            }
        }
        return true;
    }

    static void PrintArray(int[] num, ulong index)
    {
        Console.Write("(");
        for (int i = 0; i < num.Length; i++)
        {
            if (i < num.Length - 1 && ((index >> i) & 1) == 1)
            {
                Console.Write("{0}, ", num[i]);
            }
            else if (i == num.Length - 1 && ((index >> i) & 1) == 1)
            {
                Console.WriteLine("{0})", num[i]);
            }
        }
    }

    static byte GetOnesCount(ulong num)
    {
        byte counter = 0;
        for (int i = 0; i < 64; i++)
        {
            if (((num >> i) & 1) == 1)
            {
                counter++;
            }
        }
        return counter;
    }

    static void Main()
    {
        int maxLength = 0;
        ulong maxIndex = 0;
        int[] numbers = {6, 1, 4, 3, 0, 3, 6, 4, 5};
        for (ulong i = 1; i < (ulong)Math.Pow(2, numbers.Length); i++)
        {
            if (IsSorted(numbers, i))
            {
                if (GetOnesCount(i) > maxLength)
                {
                    maxLength = GetOnesCount(i);
                    maxIndex = i;
                }
            }
        }
        if (maxLength > 1)
        {
            PrintArray(numbers, maxIndex);
        }
        else
        {
            Console.WriteLine("There is no sorted subarray in the array.");
        }
    }
}

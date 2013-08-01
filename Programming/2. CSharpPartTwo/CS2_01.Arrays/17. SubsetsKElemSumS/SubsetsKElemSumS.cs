//17.* Write a program that reads three integer numbers N, K and S and an array
//of N elements from the console. Find in the array a subset of K elements that
//have sum S or indicate about its absence.

using System;

class SubsetsKElemSumS
{
    static void PrintArray(int[] arr)
    {
        Console.Write("(");
        for (int i = 0; i < arr.Length; i++)
        {
            if (i < arr.Length - 1)
            {
                Console.Write("{0}, ", arr[i]);
            }
            else
            {
                Console.WriteLine("{0})", arr[i]);
            }
        }
    }

    static void GetComb(int combPosition, int arrPosition)
    {
        if (combPosition >= comb.Length)
        {
            int sum = 0;
            for (int i = 0; i < comb.Length; i++)
            {
                sum += comb[i];
            }
            if (sum == s)
            {
                PrintArray(comb);
                foundComb = true;
            }
            return;
        }
        for (int i = arrPosition; i < arr.Length; i++)
        {
                comb[combPosition] = arr[i];
                GetComb(combPosition + 1, i + 1);
        }
    }

    static int[] arr;
    static int[] comb;
    static int s;
    static bool foundComb = false;


    static void Main()
    {
        Console.WriteLine("Please input an array size:");
        int n = int.Parse(Console.ReadLine());
        arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Please input element {0}", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Please input subset length:");
        int k = int.Parse(Console.ReadLine());
        comb = new int[k];
        Console.WriteLine("Please input the subset sum:");
        s = int.Parse(Console.ReadLine());
        GetComb(0, 0);
        if (!foundComb)
        {
            Console.WriteLine("There is no subset with sum {0} in the array.", s);
        }
    }
}

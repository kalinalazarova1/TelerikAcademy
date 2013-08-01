//21.Write a program that reads two numbers N and K and generates all
//the combinations of K distinct elements from the set [1..N]. Example:
//N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;

class Combinations
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

    static void GetComb(int[] comb, int combPosition, int nextNumber, int endNumber)
    {
        if (combPosition >= comb.Length)
        {
            PrintArray(comb);
            return;
        }
        for (int i = nextNumber; i <= endNumber; i++)
        {
                comb[combPosition] = i;
                GetComb(comb, combPosition + 1, i + 1, endNumber);
        }
    }

    static void Main()
    {
        Console.WriteLine("Please input number:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please input variation size:");
        int k = int.Parse(Console.ReadLine());
        int[] combinations = new int[k];
        GetComb(combinations, 0, 1, n);
    }
}

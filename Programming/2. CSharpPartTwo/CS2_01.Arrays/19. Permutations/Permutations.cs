//19.* Write a program that reads a number N and generates and prints all the permutations
//of the numbers [1 … N]. Example:
//n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}        

using System;

class Permutations
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

    static void GetComb(int[] comb, bool[]isUsed, int combPosition, int nextNumber, int endNumber)
    {
        if (combPosition >= comb.Length)
        {
            PrintArray(comb);
            return;
        }
        for (int i = 1; i <= endNumber; i++)
        {
            if (!isUsed[i])
            {
                comb[combPosition] = i;
                isUsed[i] = true;
                GetComb(comb, isUsed, combPosition + 1, i + 1, endNumber);
                isUsed[i] = false;
            }
        }
    }
    
    static void Main()
    {
        Console.WriteLine("Please input number:");
        int n = int.Parse(Console.ReadLine());
        int[] permutations = new int[n];
        bool[] isUsed = new bool[n + 1];
        GetComb(permutations, isUsed, 0, 1, n);
    }
}

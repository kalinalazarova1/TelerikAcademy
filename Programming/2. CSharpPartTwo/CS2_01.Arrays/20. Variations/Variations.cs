//20.Write a program that reads two numbers N and K and generates all 
//the variations of K elements from the set [1..N]. Example:
// N = 3, K = 2  -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

using System;

class Variations
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

    static void GetComb(int[] comb, int combPosition, int endNumber)
    {
        if (combPosition >= comb.Length)
        {
            PrintArray(comb);
            return;
        }
        for (int i = 1; i <= endNumber; i++)
        {
                comb[combPosition] = i;
                GetComb(comb, combPosition + 1, endNumber);
        }
    }

    static void Main()
    {
        Console.WriteLine("Please input number:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please input variation size:");
        int k = int.Parse(Console.ReadLine());
        int[] variations = new int[k];
        GetComb(variations, 0, n);
    }
}

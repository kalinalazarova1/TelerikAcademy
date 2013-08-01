using System;

class Problem_9_8
{
    static int GetMax(int a, int b)
    {
        if (a >= b)
            return a;
        else
            return b;
    }

    static int[] SumBigNumbers(int[] first, int[] second)
    {
        int[] sum = new int[GetMax(first.GetLength(0), second.GetLength(0)) + 1];
        for (int i = 0; i < GetMax(first.GetLength(0), second.GetLength(0)); i++)
        {
            if (i < first.GetLength(0) && i < second.GetLength(0))
            {
                sum[i] = first[i] + second[i] + sum[i];
            }
            else if (i >= first.GetLength(0))
            {
                sum[i] += second[i];
            }
            else 
            {
                sum[i] += first[i];
            }
            if (sum[i] > 9)
            {
                sum[i] -= 10;
                sum[i + 1] = 1;
            }
        }
        return sum;
    }

    static void PrintReverseArray(int[] arr)
    {
        for (int i = arr[arr.GetLength(0) - 1] == 0 ? arr.GetLength(0) - 2 : arr.GetLength(0) - 1; i >= 0; i--)
        {
                Console.Write(arr[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] firstNum = {1, 4, 5, 9, 5, 8, 9};
        int[] secondNum = {1, 0, 8, 7, 1, 8, 9};
        PrintReverseArray(firstNum);
        Console.WriteLine("+");
        PrintReverseArray(secondNum);
        Console.WriteLine("=");
        PrintReverseArray(SumBigNumbers(firstNum, secondNum));
    }
}

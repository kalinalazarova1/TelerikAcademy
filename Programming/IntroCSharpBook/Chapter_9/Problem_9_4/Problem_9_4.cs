using System;

class Problem_9_4
{
    static int GetCount(int[] arr, int num)
    {
        int count = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            if (arr[i] == num)
            {
                count++;
            }
        }
        return count;
    }

    static void Main()
    {
        int[] arr = new int[10];
        int proofElem;
        Console.WriteLine("Please input the array 10 elements: ");
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            arr[i] = Int32.Parse(Console.ReadLine());
        }
        Console.WriteLine("Please input number: ");
        proofElem = Int32.Parse(Console.ReadLine());
        Console.WriteLine("The count of number {0} in the array is {1}.", proofElem, GetCount(arr,proofElem));
    }
}

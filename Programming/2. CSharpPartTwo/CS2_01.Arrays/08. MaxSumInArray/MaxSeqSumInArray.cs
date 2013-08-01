//8. Write a program that finds the sequence of maximal sum in given array. Example:
//    {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
//    Can you do it with only one loop (with single scan through the elements of the array)?

using System;

class MaxSeqSumInArray
{
    static void Main()
    {
        int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int maxSeqIndex;
        int seqIndex = maxSeqIndex = 0;
        int maxSum = arr[0];
        int maxSeqLength = 1;
        int sum = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            sum += arr[i];
            if (arr[i] > sum)
            {
                sum = arr[i];
                seqIndex = i;
            }
            if (sum > maxSum)
            {
                maxSum = sum;
                maxSeqIndex = seqIndex;
                maxSeqLength = i - seqIndex + 1;
            }
        }
        Console.Write("{");
        for (int i = maxSeqIndex; i < maxSeqIndex + maxSeqLength; i++)
        {
            if (i == maxSeqLength + maxSeqIndex - 1)
            {
                Console.Write("{0}", arr[i]);
            }
            else
            {
                Console.Write("{0}, ", arr[i]);
            }
        }
        Console.WriteLine("}");
    }
}

//1. What is the expected running time of the following C# code? Explain why. Assume the array's size is n.
//
//Solution:
// If the size of the array is n then the for loop is executed n times. The while loop is executed n - 1 times.
// On each step the start and end will move towards each other until they meet and will make as many step as the size of the 
// array but on the last step when the met the while loop will not be executed and the total steps are n - 1, not n.
// We assume n - 1 to be relatively equal to n because 1 is relatively smaller than n.
// The inner if executes one operation (I do not count the operation for increasing the counter because it is only
// for test purposes) and it does not depend on the array size and this means 1 * n * n which is n * n.
// Therefore the method Compute runs in quadratic time O(n * n).

using System;

class Program
{
    static long Compute(int[] arr)
    {
        long count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
                if (arr[start] < arr[end])
                { start++; count++; }
                else
                { end--; count++; }
        }
        return count;
    }

    static void Main()
    {
        int n = 100;            //could be tested with different values of n
        Console.WriteLine("For array of size {0} executes {1} operations", n, Compute(new int[n]));
    }
}

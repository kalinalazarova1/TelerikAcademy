//10. Write a program that finds in given array of integers a sequence of given sum S (if present). 
//Example:  {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5} 

using System;

class SequenceSumS
{
    static void Main()
    {
        int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
        int s = 11;
        for (int i = 0; i < arr.Length; i++)
        {
            int sum = 0;
            for (int j = i; j < arr.Length; j++)
            {
                sum += arr[j];
                if (sum == s)
                {
                    Console.WriteLine("The sum {0} is made by the elements:", s);
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write("{0} ", arr[k]);
                    }
                    Console.WriteLine();
                    return;
                }
            }
        }
        Console.WriteLine("There are no such elements which sum is {0}.", s);
    }
}

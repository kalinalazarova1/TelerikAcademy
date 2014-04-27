//4. Write a method that finds the longest subsequence of equal numbers in given List<int>
//and returns the result as new List<int>. Write a program to test whether the method works correctly.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<int> LongestSeqEqual(List<int> list)
    {
        var result = new List<int>();
        int maxLength = 1;
        int currentLength = 1;
        int maxStart = 0;
        int currentStart = 0;
        for (int i = 1; i < list.Count; i++)
        {
            if(list[i - 1] == list[i])
            {
                currentLength++;
            }
            else
            {
                currentStart = i;
                currentLength = 1;
            }
            if(currentLength > maxLength)
            {
                maxLength = currentLength;
                maxStart = currentStart;
            }
        }
        for (int i = maxStart; i < maxStart + maxLength; i++)
        {
            result.Add(list[i]);
        }
        return result;
    }

    static void Main()
    {
        var list = new List<int>();
        Console.WriteLine("Please input a sequence of integers ending with empty line:");
        try
        {
            for (string input = Console.ReadLine(); input != string.Empty; input = Console.ReadLine())
            {
                list.Add(int.Parse(input));
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine("The input number was not in the correct format.");
        }
        Console.WriteLine("The longest sequence is: ");
        foreach (var item in LongestSeqEqual(list))
        {
            Console.WriteLine(item);
        }
    }
}

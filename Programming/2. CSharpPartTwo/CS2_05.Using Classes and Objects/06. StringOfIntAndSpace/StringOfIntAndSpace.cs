//6. You are given a sequence of positive integer values written into a string, separated by spaces. 
//Write a function that reads these values from given string and calculates their sum. Example:
//string = "43 68 9 23 318" -> result = 461

using System;

class StringOfIntAndSpace
{
    static void PrintSum(string input)
    {
        int sum = 0;
        string[] inputNumbers = input.Split(' ');
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            sum += int.Parse(inputNumbers[i]);
        }
        Console.WriteLine(sum);
    }

    static void Main()
    {
        string input = "43 68 9 23 318";
        PrintSum(input);
    }
}

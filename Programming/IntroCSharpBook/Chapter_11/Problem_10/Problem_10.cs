using System;
using System.Collections.Generic;

class Problem_10
{
    static void Main()
    {
        uint sum = 0;
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            sum = sum + uint.Parse(numbers[i]);
        }
        Console.WriteLine(sum);
    }
}

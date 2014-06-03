// 2. Refactor the following loop: 

using System;

public class Program
{
    internal static void Main()
    {
        int[] array = { 5, 11, 15, 20, 25, 30, 37, 40, 42, 47, 50, 55, 60, 63 };
        bool isFound = false;
        int expectedValue = 50;

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
            if (i % 10 == 0)
            {
                if (array[i] == expectedValue)
                {
                    isFound = true;
                    break;
                }
            }
        }

        // More code here
        if (isFound)
        {
            Console.WriteLine("Value Found!");
        }
    }
}

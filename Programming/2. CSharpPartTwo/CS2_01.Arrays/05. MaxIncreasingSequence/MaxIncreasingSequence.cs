//5. Write a program that finds the maximal sequence of increasing elements in an array.

using System;

class MaxIncreasingSequence
{
    static void Main()
    {
        int[] numbers = { 3, 2, 3, 4, 2, 2, 4 };
        uint maxSequence = 0;
        uint currentSequence = 1;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                currentSequence++;
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                }
            }
            else
            {
                currentSequence = 1;
            }
        }
        Console.WriteLine("The longest sequence of increasing elements is {0} elements long.", maxSequence);
    }
}

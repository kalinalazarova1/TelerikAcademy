//4. Write a program that finds the maximal sequence of equal elements in an array.

using System;

class MaxSequence
{
    static void Main()
    {
        int[] numbers = {2,1,1,2,3,3,2,2,2,3};
        uint maxSequence = 0;
        int maxElementIndex = 0;
        uint currentSequence = 1;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                currentSequence++;
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    maxElementIndex = i;
                }
            }
            else
            {
                currentSequence = 1;
            }
        }
        Console.WriteLine("The longest sequence of equals is {0} elements long and consists of: {1}", maxSequence, numbers[maxElementIndex]);
    }
}

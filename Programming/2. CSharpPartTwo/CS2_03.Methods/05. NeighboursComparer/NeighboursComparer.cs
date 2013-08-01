//5. Write a method that checks if the element at given position in given array of integers is
//bigger than its two neighbours (when such exist).

using System;

class NeighboursComparer
{
    static bool isBiggerThanNeighbours(int[] arr, int index)
    {
        if (index + 1 > arr.Length || index - 1 < 0)
        {
            throw new IndexOutOfRangeException("The initial index or its neighbours is out of the range of the array.");
        }
        if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        int[] test = { 2,4,7,2,5,5,6,2};
        int testIndex = 2;
        try
        {
            if (isBiggerThanNeighbours(test, testIndex))
            {
                Console.WriteLine("The element at index {0} is bigger than its neighbours.", testIndex);
            }
            else
            {
                Console.WriteLine("The element at index {0} is NOT bigger than its neighbours.", testIndex);
            }
        }
        catch(IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

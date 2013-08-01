//6. Write a method that returns the index of the first element in array that is bigger than
//its neighbours, or -1, if there is no such element. 
// - Use the method from the previous exercise.

using System;

class FirstBiggerThanNeighbours
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

    static int GetFisrtBiggerThanNeighbours(int[] arr)
    {
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (isBiggerThanNeighbours(arr, i))
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        int[] test = { 2, 4, 7, 2, 5, 5, 6, 2 };
        //int[] test = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int index = GetFisrtBiggerThanNeighbours(test);
        if (index >= 0)
        {
            Console.WriteLine("The element at index {0} is the first bigger than its neighbours.", index);
        }
        else
        {
            Console.WriteLine("There is no such element in the array which is bigger than its neighbours.");
        }
    }
}

//4. Write a methods that counts how many times given number appears in given array. Write a test 
//program to check if the method is wrking correctly.

using System;

class CountNumbersInArray
{
    static int GetNumberCount(int[] arr, int num)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int index = Array.IndexOf(arr, num, i);
            if (index >= 0)
            {
                count++;
                i = index;
            }
        }
        return count;
    }

    static void Main()
    {
        int[] test = {6,6,2,3,4,6,7,8,5,6,6,8,5,7,6,8,5,7,8,7,6,5,7,8,6};
        int testNumber = 6;
        Console.WriteLine("The number {0} is found {1} times in the array.", testNumber, GetNumberCount(test, testNumber));
    }
}

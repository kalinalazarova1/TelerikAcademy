//2. Write a program that reads two arrays from the console and compares them element by element

using System;

class ArrayComparer
{
    static void Main()
    {
        bool isEqual = true;
        int[] firsrtArray = new int[10];
        int[] secondArray = new int[10];
        for (int i = 0; i < firsrtArray.Length; i++)
        {
            Console.WriteLine("Please input element {0} from the first array:", i);
            firsrtArray[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < secondArray.Length; i++)
        {
            Console.WriteLine("Please input element {0} from the second array:", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < firsrtArray.Length; i++)
        {
            if (firsrtArray[i] != secondArray[i])
            {
                isEqual = false;
                break;
            }
        }
        if (isEqual)
        {
            Console.WriteLine("The two arrays are equal.");
        }
        else
        {
            Console.WriteLine("The two array are not equal.");
        }
    }
}

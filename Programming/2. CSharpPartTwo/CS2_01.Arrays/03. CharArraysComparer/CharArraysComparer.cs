//3. Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class CharArraysComparer
{
    static void Main()
    {
        bool isEqual = true;
        char[] firsrtArray = new char[10];
        char[] secondArray = new char[10];
        for (int i = 0; i < firsrtArray.Length; i++)
        {
            Console.WriteLine("Please input element {0} from the first array:", i);
            firsrtArray[i] = char.Parse(Console.ReadLine());
        }
        for (int i = 0; i < secondArray.Length; i++)
        {
            Console.WriteLine("Please input element {0} from the second array:", i);
            secondArray[i] = char.Parse(Console.ReadLine());
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

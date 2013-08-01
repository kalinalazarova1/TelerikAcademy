using System;

class Problem_8_6
{
    static void Main()
    {
        int decNumber;
        int[] arr = new int[32];
        int i;
        Console.WriteLine("Please input decimal number:");
        decNumber = Int32.Parse(Console.ReadLine());
        Console.Write("The heximal equivalent of {0} is: ", decNumber);
        for (i = 0; i < 32 && decNumber > 0; i++)
        {
            arr[i] = decNumber % 16;
            decNumber /= 16;
        }
        while (i > 0)
        {
            i--;
            switch (arr[i])
            {
                case 10: Console.Write("A"); break;
                case 11: Console.Write("B"); break;
                case 12: Console.Write("C"); break;
                case 13: Console.Write("D"); break;
                case 14: Console.Write("E"); break;
                case 15: Console.Write("F"); break;
                default: Console.Write(arr[i]); break;
            }
        }
        Console.WriteLine();
    }
}


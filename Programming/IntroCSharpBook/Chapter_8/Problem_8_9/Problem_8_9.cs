using System;

class Problem_8_9
{
    static void Main()
    {
        int decNumber = 0;
        char[] arr = new char[32];
        int temp = 0;
        int i = 0;
        int powerOfTwo = 1;
        int[] res = new int[8];
        Console.WriteLine("Please input binary number:");
        while (temp != 10)
        {
            temp = Console.Read();
            arr[i] = Convert.ToChar(temp);
            i++;
        }
        Console.Write("The heximal equivalent of ");
        i -= 3;
        for (int j = 0; j <= i; j++)
        {
            Console.Write(arr[j]);
        }
        Console.Write(" is: ");
        while (i >= 0)
        {
            if (arr[i] == '1')
            {
                decNumber += powerOfTwo;
            }
            powerOfTwo *= 2;
            i--;
        }
        for (i = 0; i < 32 && decNumber > 0; i++)
        {
            res[i] = decNumber % 16;
            decNumber /= 16;
        }
        while (i > 0)
        {
            i--;
            switch (res[i])
            {
                case 10: Console.Write("A"); break;
                case 11: Console.Write("B"); break;
                case 12: Console.Write("C"); break;
                case 13: Console.Write("D"); break;
                case 14: Console.Write("E"); break;
                case 15: Console.Write("F"); break;
                default: Console.Write(res[i]); break;
            }
        }
        Console.WriteLine();
    }
}


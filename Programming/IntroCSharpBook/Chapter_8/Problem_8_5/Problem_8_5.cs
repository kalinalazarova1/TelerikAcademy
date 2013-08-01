using System;

class Problem_8_5
{
    static void Main()
    {
        int decNumber = 0;
        char[] arr = new char[32];
        int temp = 0;
        int i = 0;
        int powerOfTwo = 1;
        Console.WriteLine("Please input binary number:");
        while(temp != 10)
        {
            temp = Console.Read();
            arr[i] = Convert.ToChar(temp);
            i++;
        }
        Console.Write("The decimal equivalent of ");
        i -= 3;
        for(int j = 0; j <= i; j++)
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
        Console.Write(decNumber);
        Console.WriteLine();
    }
}

using System;

class SevenlandNumbers
{
    static void Main()
    {
        int decNumber = 0;
        string digit = " ";
        int k = int.Parse(Console.ReadLine());
        for (int i = 2; i >= 0; i--)
        {
            decNumber = decNumber + (int) Math.Pow(7, i)*(k / (int) Math.Pow(10, i));
            k = k % (int) Math.Pow(10, i);
        }
        decNumber += 1;
        while (decNumber != 0)
        {
            digit = decNumber % 7 + digit;
            decNumber = decNumber / 7;
        }
        digit.TrimEnd(' ');
        Console.WriteLine(digit);
    }
}

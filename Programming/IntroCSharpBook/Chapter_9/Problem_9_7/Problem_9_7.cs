using System;

class Problem_9_7
{
    static void PrintReverseNumber(int num)
    {
        for (num = Math.Abs(num); num != 0; num /= 10)
        {
            Console.Write(num % 10);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int intNumber;
        Console.WriteLine("Please input integer number:");
        intNumber = Int32.Parse(Console.ReadLine());
        PrintReverseNumber(intNumber);
    }
}

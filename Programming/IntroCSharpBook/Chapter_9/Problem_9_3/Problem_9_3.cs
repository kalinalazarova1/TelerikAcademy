using System;

class Problem_9_3
{
    static string GetLastDigit(int num)
    {
        switch (Math.Abs(num) % 10)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            default: return "nine";
        }
    }

    static void Main()
    {
        int intNum;
        Console.WriteLine("Please input integer number:");
        intNum = Int32.Parse(Console.ReadLine());
        Console.WriteLine("The last digit is {0}.", GetLastDigit(intNum));
    }
}


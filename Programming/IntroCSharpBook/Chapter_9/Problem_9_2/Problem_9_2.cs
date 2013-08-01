using System;

class Problem_9_2
{
    static int GetMax(int a, int b)
    {
        if (a >= b)
            return a;
        else
            return b;
    }
    static void Main()
    {
        int firstNum, secondNum, thirdNum;
        Console.WriteLine("Please enter first number:");
        firstNum = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please enter second number:");
        secondNum = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please enter third number:");
        thirdNum = Int32.Parse(Console.ReadLine());
        Console.WriteLine("The biggest number is: {0}", GetMax(GetMax(firstNum, secondNum),thirdNum));
    }
}

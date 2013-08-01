//2. Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program 
//that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class _GetMax
{
    static int GetMax(int first, int second)
    {
        return first >= second ? first : second;
    }

    static void Main()
    {
        Console.WriteLine("Please input three numbers:");
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int third = int.Parse(Console.ReadLine());
        Console.WriteLine("The biggest number is: {0}", GetMax(GetMax(first, second), third));
    }
}

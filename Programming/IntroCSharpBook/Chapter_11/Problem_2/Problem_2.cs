using System;

class Problem_2
{
    static void Main()
    {
        Random randomNumber = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(randomNumber.Next(100, 201));
        }
    }
}
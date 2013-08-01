using System;

class Program
{
    static uint GetScore(int number)
    {
        byte points = 0;
        for (int i = 0; i < 32; i++)
        {
            if (((number >> i) & 1) == 1)
            {
                points++;
            }
        }
        return points;
    }

    static void Main()
    {
        uint score = 0;
        int inputsCount = int.Parse(Console.ReadLine());
        inputsCount = inputsCount / 4;
        for (int i = 0; i < inputsCount; i++)
        {
            if (i < 3)
            {
                score += GetScore(int.Parse(Console.ReadLine()));
            }
            else
            {
                Console.ReadLine();
            }
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }
        Console.WriteLine(score);
    }
}


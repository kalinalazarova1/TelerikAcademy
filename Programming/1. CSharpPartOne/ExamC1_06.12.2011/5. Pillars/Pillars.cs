using System;

class Pillars
{
    static void Main()
    {
        sbyte pillar = 7;
        ushort leftCounter = 0;
        ushort rightCounter = 0;
        bool isPossible = false;
        byte[,] grid = new byte[8,8];
        for (byte i = 0; i < 8; i++)
        {
            byte line = byte.Parse(Console.ReadLine());
            for (byte j = 0; j < 8; j++)
            {
                grid[i, j] = (byte)((line >> j) & 1);
            }
        }
        for (sbyte i = 7; i >= 0; i--)
        {
            pillar = i;
            leftCounter = 0;
            rightCounter = 0;
            for (int r = 0; r < 8; r++)
            {
                for (int c = 7; c > pillar; c--)
                {
                    if (grid[r, c] == 1)
                    {
                        leftCounter++;
                    }
                }
                for (int c = pillar - 1; c >= 0; c--)
                {
                    if (grid[r, c] == 1)
                    {
                        rightCounter++;
                    }
                }
            }
            if (leftCounter == rightCounter)
            {
                Console.WriteLine(pillar);
                Console.WriteLine(leftCounter);
                isPossible = true;
                break;
            }
        }
        if (!isPossible)
        {
            Console.WriteLine("No");
        }
    }
}

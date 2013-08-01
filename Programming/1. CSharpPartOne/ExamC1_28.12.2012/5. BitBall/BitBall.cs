using System;

class BitBall
{
    static void Main()
    {
        int[,] field = new int[8,8];
        byte mask = 1;
        int scoreTopTeam = 0;
        int scoreBottmTeam = 0;
        for (int b = 0; b < 2; b++)
        {
            for (int r = 0; r < field.GetLength(0); r++)
            {
                byte line = byte.Parse(Console.ReadLine());
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    if (field[r, c] == 0 && ((line >> c) & mask) != 0)
                    {
                        field[r, c] = ((line >> c) & mask) + b;
                    }
                    else if (field[r, c] != 0 && ((line >> c) & mask) != 0)
                    {
                        field[r, c] = 0;
                    }
                }
            }
        }
        for (int c = 0; c < field.GetLength(1); c++)
        {
            for (int r = 0; r < field.GetLength(0); r++)
            {
                int temp = r;
                if (field[r, c] == 1)
                {
                    while (true)
                    {
                        temp++;
                        if (temp >= field.GetLength(0))
                        {
                            scoreTopTeam++;
                            break;
                        }
                        if (field[temp, c] != 0)
                        {
                            break;
                        }
                    }
                }
                else if (field[r, c] == 2)
                {
                    while(true)
                    {
                        temp--;
                        if (temp < 0)
                        {
                            scoreBottmTeam++;
                            break;
                        }
                        if (field[temp, c] != 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
        Console.WriteLine("{0}:{1}", scoreTopTeam, scoreBottmTeam);
    }
}

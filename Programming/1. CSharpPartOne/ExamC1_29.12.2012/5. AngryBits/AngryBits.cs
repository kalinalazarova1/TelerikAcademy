using System;

class AngryBits
{
    static int score = 0;
    static int flightLength = 0;
    static int pigCounter = 0;
    static int dir = 0;

    static void CheckPig(int r, int c, int[,] arr)
{
    if (r > 7 || r < 0 || c > 15 || c < 0)
    {
        return;
    }
    if (arr[r, c] == 1 && c < 8)
    {
        arr[r, c] = 0;
        pigCounter++;
        return;
    }
    return;
}

    static void Move(int r, int c, int[,] arr)
    {
        if (dir == 3) return;
        if (r > 7 || c < 0)
        {
            dir = 3;
            return;
        }
        if (r < 0)
        {
            dir = 1;
            return;
        }
        flightLength++;
        if (arr[r, c] == 1 && c < 8)
        {
            arr[r, c] = 0;
            pigCounter++;
            CheckPig(r + 1, c + 1, arr);
            CheckPig(r + 1, c, arr);
            CheckPig(r + 1, c - 1, arr);
            CheckPig(r - 1, c, arr);
            CheckPig(r - 1, c + 1, arr);
            CheckPig(r - 1, c - 1, arr);
            CheckPig(r, c - 1, arr);
            CheckPig(r, c + 1, arr);
            dir = 0;
            return;
        }
        if (dir == 0)   Move(r - 1, c - 1, arr);
        if (dir == 1)   Move(r + 1, c - 1, arr);
    }

    

    static void Main()
    {
        int[,] field = new int[8, 16];
        ushort row;
        string win = "Yes";
        
        for (int j = 0; j < 8; j++)
        {
            row = ushort.Parse(Console.ReadLine());
            for (int i = 0; i < 16; i++)
            {
                field[j, i] = row % 2;
                row = (ushort)(row / 2);
            }
        }
        for (int c = 8; c < 16; c++)
        {
            for (int r = 0; r < 8; r++)
            {
                if (field[r, c] == 1)
                {
                    Move(r - 1, c - 1, field);
                }
            }
            score = score + flightLength * pigCounter;
            flightLength = 0;
            pigCounter = 0;
            dir = 0;
        }
        for (int c = 0; c < 8; c++)
        {
            for (int r = 0; r < 8; r++)
            {
                if (field[r, c] == 1) win = "No";
            }
        }
        Console.WriteLine("{0} {1}", score, win);
    }
}

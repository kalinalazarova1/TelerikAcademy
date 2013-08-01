using System;

class AngryBits
{
    static int score = 0;
    static int flightLength = 0;
    static int pigCounter = 0;

    static void Move(int r, int c, int dir, int[,] arr)
    {
        if (r < 0)
        {
            Move(r + 2, c, 1,arr);
            return;
        }
        if (r > 7 || c < 0)
        {
            return;
        }
        flightLength++;
        if (arr[r, c] == 1 && c < 8)
        {
            arr[r, c] = 0;
            pigCounter++;
            if (r < 7 && c < 15 && arr[r + 1, c + 1] == 1)
            {
                arr[r + 1, c + 1] = 0;
                pigCounter++;
            }
            if (r < 7 && arr[r + 1, c] == 1)
            {
                arr[r + 1, c] = 0;
                pigCounter++;
            }
            if (r < 7 && c > 0 && arr[r + 1, c - 1] == 1)
            {
                arr[r + 1, c - 1] = 0;
                pigCounter++;
            }
            if (r > 0 && arr[r - 1, c] == 1)
            {
                arr[r - 1, c] = 0;
                pigCounter++;
            }
            if (r > 0 && c < 15 && arr[r - 1, c + 1] == 1)
            {
                arr[r - 1, c + 1] = 0;
                pigCounter++;
            }
            if (r > 0 && c > 0 && arr[r - 1, c - 1] == 1)
            {
                arr[r - 1, c - 1] = 0;
                pigCounter++;
            }
            if (c > 0 && arr[r, c - 1] == 1)
            {
                arr[r, c - 1] = 0;
                pigCounter++;
            }
            if (c < 15 && arr[r, c + 1] == 1)
            {
                arr[r, c + 1] = 0;
                pigCounter++;
            }
            return;
        }
        if (dir == 0)
        {
            Move(r - 1, c - 1, 0, arr);
        }
        else
        {
            Move(r + 1, c - 1, 1, arr);
        }
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
                field[j, i] = (row >> i) & 1;
            }
        }
        for (int c = 8; c < 16; c++)
        {
            for (int r = 0; r < 8; r++)
            {
                if (field[r, c] == 1 && r > 0)
                {
                    field[r, c] = 0;
                    Move(r - 1, c - 1, 0,field);
                }
                else if(field[r, c] == 1 && r == 0)
                {
                    field[r, c] = 0;
                    Move(r + 1, c - 1, 1, field);
                }
            }
            score = score + flightLength * pigCounter;
            flightLength = 0;
            pigCounter = 0;
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

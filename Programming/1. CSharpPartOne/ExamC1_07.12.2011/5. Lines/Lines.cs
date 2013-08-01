using System;

class Lines
{
    static byte GetLineLenght(byte[,] arr, byte r, byte c, byte dir)
    {
        byte length = 0;
        while (r < arr.GetLength(0) && c < arr.GetLength(1) && arr[r, c] == 1)
        {
            if (dir == 0)
            {
                r++;
                length++;
            }
            else if (dir == 1)
            {
                c++;
                length++;
            }
        }
        return length;
    }

    static void Main()
    {
        byte maxLenght = 0;
        byte linesCount = 0;
        byte[,] grid = new byte[8,8];
        for (byte r = 0; r < 8; r++)
        {
            byte line = byte.Parse(Console.ReadLine());
            for (byte c = 0; c < 8; c++)
            {
                grid[r, c] = (byte)((line >> c) & 1);
            }
        }
        for (byte r = 0; r < 8; r++)
        {
            for (byte c = 0; c < 8; c++)
            {
                if (grid[r, c] == 1)
                    {
                        if (GetLineLenght(grid, r, c, 0) > maxLenght)
                        {
                            maxLenght = GetLineLenght(grid, r, c, 0);
                            linesCount = 1;
                        }
                        else if (GetLineLenght(grid, r, c, 0) == maxLenght)
                        {
                            linesCount++;
                        }
                        if (GetLineLenght(grid, r, c, 1) > maxLenght)
                        {
                            maxLenght = GetLineLenght(grid, r, c, 1);
                            linesCount = 1;
                        }
                        else if (GetLineLenght(grid, r, c, 1) == maxLenght && maxLenght != 1)
                        {
                            linesCount++;
                        }
                    }
                }
            }
        Console.WriteLine(maxLenght);
        Console.WriteLine(linesCount);
    }
}

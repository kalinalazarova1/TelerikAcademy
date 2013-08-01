using System;

class Neurons
{
    static void FillNeurons()
    {
        for (byte r = 0; r < 32; r++)
        {
            for(byte c = 0; c < 32; c++)
            {
                if (grid[r, c] == 1 && !isOutside[r, c])
                {
                    grid[r, c] = 0;
                }
                else if(grid[r, c] == 0 && !isOutside[r, c])
                {
                    grid[r, c] = 1;
                }
            }
        }
    }

    static void PrintGrid(byte limit)
    { 
        for (byte r = 0; r < limit; r++)
        {
            uint result = 0;  
            for(sbyte c = 31; c >= 0; c--)
            {
                result += grid[r, c] * (uint)Math.Pow(2, c);
            }
            Console.WriteLine(result);
        }
    }

    static void FindOutsideArea(byte limit)
    {
        for (byte r = 0; r < limit; r++)
        {
            byte leftMargin = 0;
            byte rightMargin = 31;
            for (byte c = 0; c < 32; c++)
            {
                if (grid[r, c] == 1)
                {
                    rightMargin = c;
                    break;
                }
            }
            for (sbyte c = 31; c >= 0; c--)
            {
                if (grid[r, c] == 1)
                {
                    leftMargin = (byte)c;
                    break;
                }
            }
            if (leftMargin >= rightMargin)
            {
                for (sbyte c = 31; c > leftMargin; c--)
                {
                    isOutside[r, c] = true;
                }
                for (byte c = 0; c < rightMargin; c++)
                {
                    isOutside[r, c] = true;
                }
            }
            else
            {
                for (byte c = 0; c < 32; c++)
                {
                    isOutside[r, c] = true;
                }
            }
        }
    }

    static void FindOutsideArea(byte r, byte c)
    {
        if (r >= 32 || r < 0 || c >= 32 || c < 0)
        {
            return;
        }
        if (grid[r, c] == 1)
        {
            return;
        }
        if (isOutside[r, c] == true)
        {
            return;
        }
        isOutside[r, c] = true;
        FindOutsideArea((byte)(r + 1), c);
        FindOutsideArea(r, (byte)(c + 1));
        FindOutsideArea((byte)(r - 1), c);
        FindOutsideArea(r, (byte)(c - 1));
    }

    static byte [,] grid = new byte [32,32];
    static bool [,] isOutside = new bool[32,32];

    static void Main()
    {
        bool isValid = true;
        byte counter = 0;
        for (; ; counter++)
        {
            uint line;
            isValid = uint.TryParse(Console.ReadLine(), out line);
            if (!isValid)
            {
                break;
            }
            for (byte j = 0; j < 32; j++)
            {
                grid[counter, j] = (byte)((line >> j) & 1);
            }
        }
        //FindOutsideArea(0, 0);
        //FindOutsideArea((byte)(counter - 1), 0);
        //FindOutsideArea(0, (byte)31);
        //FindOutsideArea((byte)(counter - 1), (byte)31);
        FindOutsideArea(counter);
        FillNeurons();
        PrintGrid(counter);
    }
}

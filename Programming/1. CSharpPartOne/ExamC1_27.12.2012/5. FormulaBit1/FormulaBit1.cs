using System;

class FormulaBit1
{
    static byte[,] grid = new byte[8, 8];
    static byte trackLength = 0;
    static byte turnCount = 0;
    static bool searchIsOver = false;

    static void Move(sbyte r, sbyte c, byte curDir, byte nextDir)
    {
        if (searchIsOver) return;
        if (r > 7) return;
        if (c > 7) return;
        if (r < 0) return;
        if (c < 0) return;
        if (grid[r, c] == 1)
        {
            if (grid[0, 0] == 1)
            {
                Console.WriteLine("No 0");
            }
            return;
        }
        if (r == 7 && c == 7)
        {
            trackLength++;
            Console.WriteLine("{0} {1}", trackLength, turnCount);
            searchIsOver = true;
            return;
        }
        trackLength++;
        if(curDir == 0 && nextDir == 1)
        {
            
            Move((sbyte)(r + 1), c, 0, 1);
            if((c > 6 || grid[r, c + 1] == 1)  && !searchIsOver)
            {
                Console.WriteLine("No {0}", trackLength);
                searchIsOver = true;
                return;
            }
            turnCount++;
            Move(r, (sbyte)(c + 1), 1, 2);
        }
        else if(curDir == 1 && nextDir == 2)
        {
            Move(r, (sbyte)(c + 1), 1, 2);
            if ((r == 0 || grid[r - 1, c] == 1)  && !searchIsOver)
            {
                Console.WriteLine("No {0}", trackLength);
                searchIsOver = true;
                return;
            }
            turnCount++;
            Move((sbyte)(r - 1), c, 2, 1);
        }
        else if(curDir == 1 && nextDir == 0)
        {
            Move(r, (sbyte)(c + 1), 1, 0);
            if ((r > 6 || grid[r + 1, c] == 1 ) && !searchIsOver)
            {
                Console.WriteLine("No {0}", trackLength);
                searchIsOver = true;
                return;
            }
            turnCount++;
            Move((sbyte)(r + 1), c, 0, 1);
        }
        else if(curDir == 2 && nextDir == 1)
        {
            Move((sbyte)(r - 1), c, 2, 1);
            if ((c > 6 || grid[r, c + 1] == 1) && !searchIsOver)
            {
                Console.WriteLine("No {0}", trackLength);
                searchIsOver = true;
                return;
            }
            turnCount++;
            Move(r, (sbyte)(c + 1), 1, 0); 
        }
    }

    static void Main()
    {
        for (byte i = 0; i < 8; i++)
        {
            byte gridLine = byte.Parse(Console.ReadLine());
            for (byte j = 0; j < 8; j++)
			{
                grid[i, j] = (byte)((gridLine >> j) & 1);
            }
        }
        Move(0, 0, 0, 1);
    }
}

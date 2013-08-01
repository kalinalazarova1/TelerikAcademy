using System;

class FormulaBit1v2
{
    static void Main()
    {
        byte[,] grid = new byte[8, 8];
        byte trackLength = 0;
        byte turnCount = 0;
        sbyte r = 0;             //start position grid[0, 0]
        sbyte c = 0;
        byte curDir = 0;        //south
        byte nextDir = 1;       //west
        bool dirChanged = false;
        for (byte i = 0; i < 8; i++)
        {
            byte gridLine = byte.Parse(Console.ReadLine());
            for (byte j = 0; j < 8; j++)
            {
                grid[i, j] = (byte)((gridLine >> j) & 1);
            }
        }
        if (grid[0, 0] == 1)
        {
            Console.WriteLine("No 0");
            return;
        }
        else trackLength = 1;
        while (true)
        {
            if (curDir == 0) r++;               //Move foward
            else if (curDir == 1) c++;
            else if (curDir == 2) r--;
            trackLength++;
            if (c == 7 && r == 7)               //Check if end is reached successfully
            {
                if(grid[7, 7] == 0)             //The last cell is free
                {
                    Console.WriteLine("{0} {1}", trackLength, turnCount);
                    break;
                }
                else
                {
                    trackLength--;
                    Console.WriteLine("No {0}", trackLength);   //The last cell is blocked
                    break;
                }
            }
            if (c < 0 || c > 7 || r < 0 || r > 7 || grid[r, c] == 1)    //Check if it is possible to move in the current direction
            {                                                           // if not return and change direction
                trackLength--;
                if (dirChanged)             //no way out of the grid
                {
                    Console.WriteLine("No {0}", trackLength);
                    break;
                } 
                turnCount++;
                dirChanged = true;
                if (c < 0) c++;                                         //Go back;
                else if (c > 7) c--;
                else if (r < 0) r++;
                else if (r > 7) r--;
                else if (grid[r, c] == 1)
                {
                    if (curDir == 0) r--;
                    else if (curDir == 1) c--;
                    else r++;
                }
                if (nextDir == 0 || nextDir == 2)                       //Change direction
                {
                    curDir = nextDir;
                    nextDir = 1;
                }
                else if (nextDir == 1 && curDir == 0)
                {
                    curDir = nextDir;
                    nextDir = 2;
                }
                else
                {
                    curDir = nextDir;
                    nextDir = 0;
                }
            }
            else
            {
                dirChanged = false;                         //No change in direction in this loop
            }
        }

    }
}

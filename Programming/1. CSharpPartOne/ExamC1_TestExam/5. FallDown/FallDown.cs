using System;

class FallDown
{
    static void Main()
    {
        byte[,] grid = new byte[8, 8];
        for (byte i = 0; i < 8; i++)
			{
                byte inputLine = byte.Parse(Console.ReadLine());
                for (byte j = 0; j < 8; j++)
                {
                    grid[i, j] = (byte)((inputLine >> j) & 1);
                }
			}
        for (int r = 6; r >= 0; r--)
        {
            for (int c = 7; c >= 0; c--)
            {
                if (grid[r, c] == 1)
                {
                    grid[r, c] = 0;
                    while (true)
                    {
                        r++;
                        if (r > 7 || grid[r, c] == 1)
                        {
                            r--;
                            grid[r, c] = 1;
                            break;
                        }
                        
                    }
                }
            }
        }
        for (byte r = 0; r < 8; r++)
        {
            byte decimalNumber = 0;
            for (byte c = 0; c < 8; c++)
            {
                decimalNumber += (byte)(grid[r, c] * Math.Pow(2, c));
            }
            Console.WriteLine(decimalNumber);
        }
    }
}

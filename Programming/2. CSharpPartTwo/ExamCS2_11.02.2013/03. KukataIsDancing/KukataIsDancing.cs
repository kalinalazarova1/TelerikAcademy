using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class KukataIsDancing
{
    static string GetLastColor(string dance)
    {
        sbyte dir = 0;
        sbyte row = 1;
        sbyte col = 1;
        for (byte i = 0; i < dance.Length; i++)
        {
            switch (dance[i])
            {
                case 'L': dir++; break;
                case 'R': dir--; break;
                case 'W':
                    {
                        if (dir == 0) row--;
                        else if (dir == 1) col++;
                        else if (dir == 2) row++;
                        else if (dir == 3) col--;
                            break;
                    }
            }
            if (dir < 0) dir = 3;
            else if (dir > 3) dir = 0;
            if (row > 2) row = 0;
            else if (row < 0) row = 2;
            else if (col > 2) col = 0;
            else if (col < 0) col = 2;
        }
        switch (danceFloor[row, col])
        {
            case 'R': return "RED";
            case 'G': return "GREEN";
            case 'B': return "BLUE";
            default: return "ERROR";
        }
    }

    static char[,] danceFloor = {{'R','B','R'},{'B','G','B'},{'R','B','R'}};

    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        string[] dance = new string[n];
        for (byte i = 0; i < n; i++)
        {
            dance[i] = Console.ReadLine();
        }
        for (byte i = 0; i < n; i++)
        {
            Console.WriteLine(GetLastColor(dance[i]));
        }
    }
}

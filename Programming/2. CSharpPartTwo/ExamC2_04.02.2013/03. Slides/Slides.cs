using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Slides
{
    static void Move(byte cw, byte ch, byte cd, string move)
    {
        switch (move[0])
        {
            case 'S': Slide(cw, ch, cd, move.Substring(2)); break;
            case 'B': isStuck = true; break;
            case 'E':
                {
                    if (ch + 1 != cuboid.GetLength(1)) curH++;
                    else isOutOfCuboid = true;
                    break;
                }
            case 'T': Teleport(cw, ch, cd, move.Substring(2)); break;
            default: break;
        }
    }
    static void Teleport(byte cw, byte ch, byte cd, string dir)
    {
        string[] cellCord = dir.Split(' ');
        curH = ch;
        curW = byte.Parse(cellCord[0]);
        curD = byte.Parse(cellCord[1]);
        return;
    }
    static void Slide(byte cw, byte ch, byte cd, string dir)
    {
        if (ch == cuboid.GetLength(1) - 1)
        {
            isOutOfCuboid = true;
            return;
        }
        else
        {
            curH++;
        }
        for (byte i = 0; i < dir.Length; i++)
        {
            switch (dir[i])
            {
                case 'L':
                    {
                        if (cw - 1 >= 0) curW--;
                        else
                        {
                            isStuck = true;
                            curH = ch;
                            curD = cd;
                            return;
                        }
                        break;
                    }
                case 'R':
                    {
                        if (cw + 1 < cuboid.GetLength(0)) curW++;
                        else
                        {
                            isStuck = true;
                            curH = ch;
                            curD = cd;
                            return;
                        }
                        break;
                    }
                case 'F':
                    {
                        if (cd - 1 >= 0) curD--;
                        else
                        {
                            isStuck = true;
                            curH = ch;
                            return;
                        }
                        break;
                    }
                case 'B':
                    {
                        if (cd + 1 < cuboid.GetLength(2)) curD++;
                        else
                        {
                            isStuck = true;
                            curH = ch;
                            return;
                        }
                        break;
                    }
                default: break;
            }
        }
        return;
    }

    static bool isStuck = false;
    static bool isOutOfCuboid = false;
    static string[,,] cuboid;
    static byte curW;
    static byte curH;
    static byte curD;
    
    static void Main()
    {
        char[] separator = { ',', '(', ')', '|' };
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(' ');
        byte w = byte.Parse(splittedInput[0]);
        byte h = byte.Parse(splittedInput[1]);
        byte d = byte.Parse(splittedInput[2]);
        cuboid = new string[w,h,d];
        for (sbyte i = 0; i < h; i++)
        {
            input = Console.ReadLine();
            input = input.Replace(" | ", "|");
            splittedInput = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (sbyte j = 0; j < d; j++)
            {
                for (sbyte k = 0; k < w; k++)
                {
                    cuboid[k, i, j] = splittedInput[k + j * w];
                }
            }
        }
        input = Console.ReadLine();
        splittedInput = input.Split(' ');
        byte startW = byte.Parse(splittedInput[0]);
        curW = startW;
        byte startD = byte.Parse(splittedInput[1]);
        curD = startD;
        curH = 0;
        while (!isOutOfCuboid && !isStuck)
        {
            Move(curW, curH, curD, cuboid[curW, curH, curD]);
        }
        if (isStuck)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine("Yes");
        }
        Console.WriteLine("{0} {1} {2}", curW, curH, curD);
    }
}


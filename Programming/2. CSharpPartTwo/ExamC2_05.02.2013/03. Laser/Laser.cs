using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Laser
{
    static sbyte w;
    static sbyte h;
    static sbyte d;
    static bool[, ,] isBurned;
    static sbyte dirW;
    static sbyte dirH;
    static sbyte dirD;

    static bool isOutOfCuboid (sbyte curX, sbyte dimension)
    {
        if (curX < isBurned.GetLength(dimension) && curX >= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static void Move(sbyte curW, sbyte curH, sbyte curD, sbyte dirW, sbyte dirH, sbyte dirD)
    {
        while (true)
        {
            if (!isOutOfCuboid((sbyte)(curW + dirW), 0) && !isOutOfCuboid((sbyte)(curH + dirH), 1) && !isOutOfCuboid((sbyte)(curD + dirD), 2) && !isBurned[curW + dirW, curH + dirH, curD + dirD])
            {
                curW += dirW;
                curH += dirH;
                curD += dirD;
                isBurned[curW, curH, curD] = true;
            }
            else if(isOutOfCuboid((sbyte)(curW + dirW), 0) || isOutOfCuboid((sbyte)(curH + dirH), 1) || isOutOfCuboid((sbyte)(curD + dirD), 2))
            {
                if (isOutOfCuboid((sbyte)(curW + dirW), 0))
                {
                    dirW *= -1;
                }
                if (isOutOfCuboid((sbyte)(curH + dirH), 1))
                {
                    dirH *= -1;
                }
                if (isOutOfCuboid((sbyte)(curD + dirD), 2))
                {
                    dirD *= -1;
                }
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", curW + 1, curH + 1, curD + 1);
                return;
            }
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(' ');
        w = sbyte.Parse(splittedInput[0]);
        h = sbyte.Parse(splittedInput[1]);
        d = sbyte.Parse(splittedInput[2]);
        isBurned = new bool[w, h, d];
        input = Console.ReadLine();
        splittedInput = input.Split(' ');
        sbyte startW = sbyte.Parse(splittedInput[0]);
        sbyte startH = sbyte.Parse(splittedInput[1]);
        sbyte startD = sbyte.Parse(splittedInput[2]);
        input = Console.ReadLine();
        splittedInput = input.Split(' ');
        dirW = sbyte.Parse(splittedInput[0]);
        dirH = sbyte.Parse(splittedInput[1]);
        dirD = sbyte.Parse(splittedInput[2]);
            for (byte j = 0; j < w; j++)
            {
                isBurned[j, 0, 0] = true;
                isBurned[j, 0, d - 1] = true;
                isBurned[j, h - 1, 0] = true;
                isBurned[j, h - 1, d - 1] = true;
            }
            for (byte j = 0; j < d; j++)
            {
                isBurned[0, 0, j] = true;
                isBurned[w - 1, 0, j] = true;
                isBurned[0, h - 1, j] = true;
                isBurned[w - 1, h - 1, j] = true;
            }
            for (byte j = 0; j < h; j++)
            {
                isBurned[0, j, 0] = true;
                isBurned[w - 1, j, 0] = true;
                isBurned[0, j, d - 1] = true;
                isBurned[w - 1, j, d - 1] = true;
            }
        isBurned[startW - 1, startH - 1, startD - 1] = true;
        Move((sbyte)(startW - 1),(sbyte)(startH - 1), (sbyte)(startD - 1), dirW, dirH, dirD);
    }
}

using System;

class _3DLines
{
    static int maxLength = 1;

    static int maxCount = 0;

    static void CheckDirection(char[, ,] cuboid, int r, int c, int l, int lenRow, int lenCol, int lenDep)
    {
        int lenR = lenRow;
        int lenC = lenCol;
        int lenD = lenDep;
        while (r + lenR < cuboid.GetLength(0) && r + lenR >= 0 &&
               c + lenC < cuboid.GetLength(1) && c + lenC >= 0 &&
               l + lenD < cuboid.GetLength(2) && l + lenD >= 0 &&
               cuboid[r + lenR, c + lenC, l + lenD] == cuboid[r, c, l])
        {
            lenR += lenRow;
            lenC += lenCol;
            lenD += lenDep;
            int len = Math.Max(Math.Abs(lenR), Math.Max(Math.Abs(lenC), Math.Abs(lenD)));
            if (len > maxLength)
            {
                maxLength = len;
                maxCount = 1;
            }
            else if (len == maxLength)
            {
                maxCount++;
            }
        }
    }

    static void GetMaxLength(char[,,] cuboid, int r, int c, int l)
    {
        CheckDirection(cuboid, r, c, l, 1, 0, 0);
        CheckDirection(cuboid, r, c, l, 0, 1, 0);
        CheckDirection(cuboid, r, c, l, 1, 1, 0);
        CheckDirection(cuboid, r, c, l, 0, 0, 1);
        CheckDirection(cuboid, r, c, l, 0, 1, 1);
        CheckDirection(cuboid, r, c, l, 1, 0, 1);
        CheckDirection(cuboid, r, c, l, 1, 1, 1);
        CheckDirection(cuboid, r, c, l, -1, -1, 1);
        CheckDirection(cuboid, r, c, l, 1, -1, 0);
        CheckDirection(cuboid, r, c, l, -1, 1, -1);
        CheckDirection(cuboid, r, c, l, 0, 1, -1);
        CheckDirection(cuboid, r, c, l, 1, 0, -1);
        CheckDirection(cuboid, r, c, l, 1, -1, -1);
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int w = int.Parse(input[0]);
        int h = int.Parse(input[1]);
        int d = int.Parse(input[2]);
        char[,,] cuboid = new char[w, h, d];
        for (int i = 0; i < h; i++)
        {
            string[] colors = Console.ReadLine().Split(' ');
            for (int j = 0; j < d; j++)
            {
                for (int k = 0; k < w; k++)
                {
                    cuboid[k, i, j] = colors[j][k];
                }
            }
        }
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < d; j++)
            {
                for (int k = 0; k < w; k++)
                {
                    GetMaxLength(cuboid, k, i, j);
                }
            }
        }
        if (maxCount == 0)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine("{0} {1}", maxLength, maxCount);
        }
    }
}

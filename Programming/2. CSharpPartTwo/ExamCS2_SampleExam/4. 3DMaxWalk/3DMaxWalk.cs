using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int visitedSum = 0;
    static int maxRow;
    static int maxCol;
    static int maxDep;
    static int Max;
    static int secondBestMax;

    static bool isInside(int[, ,] cuboid, int startRow, int startCol, int startDep)
    {
        if (startRow < 0 || startRow >= cuboid.GetLength(0)) return false;
        if (startCol < 0 || startCol >= cuboid.GetLength(1)) return false;
        if (startDep < 0 || startDep >= cuboid.GetLength(2)) return false;
        return true;
    }

    static void GetMaxValue(int[, ,] cuboid, int startRow, int startCol, int startDep)
    {
        int curRow = startRow + 1;
        int curCol = startCol;
        int curDep = startDep;

        for (; isInside(cuboid, curRow, curCol, curDep); curRow++)
        {
            if (cuboid[curRow, curCol, curDep] > Max)
            {
                secondBestMax = Max;
                maxCol = curCol;
                maxRow = curRow;
                maxDep = curDep;
                Max = cuboid[curRow, curCol, curDep];
            }
            else if(cuboid[curRow, curCol, curDep] == Max)
            {
                secondBestMax = cuboid[curRow, curCol, curDep];
            }
        }
        curRow = startRow - 1;
        curCol = startCol;
        curDep = startDep;
        for (; isInside(cuboid, curRow, curCol, curDep); curRow--)
        {
            if (cuboid[curRow, curCol, curDep] > Max)
            {
                secondBestMax = Max;
                maxCol = curCol;
                maxRow = curRow;
                maxDep = curDep;
                Max = cuboid[curRow, curCol, curDep];
            }
            else if (cuboid[curRow, curCol, curDep] == Max)
            {
                secondBestMax = cuboid[curRow, curCol, curDep];
            }
        }
        curRow = startRow;
        curCol = startCol + 1;
        curDep = startDep;
        for (; isInside(cuboid, curRow, curCol, curDep); curCol++)
        {
            if (cuboid[curRow, curCol, curDep] > Max)
            {
                secondBestMax = Max;
                maxCol = curCol;
                maxRow = curRow;
                maxDep = curDep;
                Max = cuboid[curRow, curCol, curDep];
            }
            else if (cuboid[curRow, curCol, curDep] == Max)
            {
                secondBestMax = cuboid[curRow, curCol, curDep];
            }
        }
        curRow = startRow;
        curCol = startCol - 1;
        curDep = startDep;
        for (; isInside(cuboid, curRow, curCol, curDep); curCol--)
        {
            if (cuboid[curRow, curCol, curDep] > Max)
            {
                secondBestMax = Max;
                maxCol = curCol;
                maxRow = curRow;
                maxDep = curDep;
                Max = cuboid[curRow, curCol, curDep];
            }
            else if (cuboid[curRow, curCol, curDep] == Max)
            {
                secondBestMax = cuboid[curRow, curCol, curDep];
            }
        }
        curRow = startRow;
        curCol = startCol;
        curDep = startDep + 1;
        for (; isInside(cuboid, curRow, curCol, curDep); curDep++)
        {
            if (cuboid[curRow, curCol, curDep] > Max)
            {
                secondBestMax = Max;
                maxCol = curCol;
                maxRow = curRow;
                maxDep = curDep;
                Max = cuboid[curRow, curCol, curDep];
            }
            else if (cuboid[curRow, curCol, curDep] == Max)
            {
                secondBestMax = cuboid[curRow, curCol, curDep];
            }
        }
        curRow = startRow;
        curCol = startCol;
        curDep = startDep - 1;
        for (; isInside(cuboid, curRow, curCol, curDep); curDep--)
        {
            if (cuboid[curRow, curCol, curDep] > Max)
            {
                secondBestMax = Max;
                maxCol = curCol;
                maxRow = curRow;
                maxDep = curDep;
                Max = cuboid[curRow, curCol, curDep];
            }
            else if (cuboid[curRow, curCol, curDep] == Max)
            {
                secondBestMax = cuboid[curRow, curCol, curDep];
            }
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(' ');
        int w = int.Parse(splittedInput[0]);
        int h = int.Parse(splittedInput[1]);
        int d = int.Parse(splittedInput[2]);
        int[, ,] cuboid = new int[h, w, d];
        bool[, ,] isVisited = new bool[h, w, d];
        for (int r = 0; r < h; r++)
        {
            input = Console.ReadLine();
            splittedInput = input.Split('|');
            for (int l = 0; l < d; l++)
            {
                string[] doubleSplitted = splittedInput[l].Trim().Split(' ');
                for (int c = 0; c < w; c++)
                {
                    cuboid[r, c, l] = int.Parse(doubleSplitted[c]);
                }
            }
        }
        CubeMaxWalk(cuboid, isVisited, h / 2, w / 2, d / 2);
    }

    static void CubeMaxWalk(int[, ,] cuboid, bool[, ,] isVisited, int startRow, int startCol, int startDep)
    {
        isVisited[startRow, startCol, startDep] = true;
        visitedSum += cuboid[startRow, startCol, startDep];
        GetMaxValue(cuboid, startRow, startCol, startDep);
        if (secondBestMax == Max || isVisited[maxRow, maxCol, maxDep])
        {
            Console.WriteLine(visitedSum);
            Environment.Exit(0);
        }
        Max = secondBestMax = int.MinValue;
        CubeMaxWalk(cuboid, isVisited, maxRow, maxCol, maxDep);
    }
}

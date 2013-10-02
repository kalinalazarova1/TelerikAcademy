using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SpecialValue
{
    static void GetSpecialValue(short r, short c)
    {
        while (true)
        {
            if (r == rows.GetLength(0))
            {
                r = 0;
            }
            if (rows[r][c] < 0)
            {
                specialValue = path + Math.Abs(rows[r][c]);
                return;
            }
            if (isVisited[r][c])
            {
                return;
            }
            path++;
            isVisited[r][c] = true;
            c = rows[r][c];
            r = (short)(r + 1);
        }
    }

    static int path = 1;
    static short[][] rows;
    static bool[][] isVisited;
    static long specialValue = 0;

    static void Main()
    {
        long bestSpecialValue = 0;
        char[] separator = { ' ', ',' };
        ushort n = ushort.Parse(Console.ReadLine());
        rows = new short[n][];
        isVisited = new bool[n][];
        for (short i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] splittedInput = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            rows[i] = new short[splittedInput.Length];
            isVisited[i] = new bool[splittedInput.Length];
            for (int j = 0; j < splittedInput.Length; j++)
            {
                rows[i][j] = short.Parse(splittedInput[j]);
                isVisited[i][j] = false;
            }
        }
        for (short i = 0; i < rows[0].Length; i++)
        {
            isVisited.Initialize();
            path = 1;
            specialValue = 0;
            GetSpecialValue(0, i);
            if (specialValue > bestSpecialValue)
            {
                bestSpecialValue = specialValue;
            }
        }
        Console.WriteLine(bestSpecialValue);
    }
}

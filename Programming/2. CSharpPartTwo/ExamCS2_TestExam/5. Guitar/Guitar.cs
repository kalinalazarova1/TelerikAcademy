using System;

class Guitar
{
    static void Main()
    {
        char[] separator = { ' ', ',' };
        string[] input = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        int[] changes = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            changes[i] = int.Parse(input[i]);
        }
        int b = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        bool[,] isPosVol = new bool[m + 1, changes.Length + 1];
        isPosVol[b, 0] = true;
        for (int i = 0; i < changes.Length; i++)
        {
            for (int j = 0; j < m + 1; j++)
            {
                if (isPosVol[j, i])
                {
                    if (j + changes[i] <= m)
                    {
                        isPosVol[j + changes[i], i + 1] = true;
                    }
                    if (j - changes[i] >= 0)
                    {
                        isPosVol[j - changes[i], i + 1] = true;
                    }
                }
            }
        }
        int max = -1;
        for (int i = 0; i < m + 1; i++)
        {
            if (isPosVol[i, changes.Length] && i > max)
            {
                max = i;
            }
        }
        Console.WriteLine(max);
    }
}
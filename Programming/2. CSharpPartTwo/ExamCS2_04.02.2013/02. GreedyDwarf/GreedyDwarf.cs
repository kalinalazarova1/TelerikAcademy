using System;
using System.Collections.Generic;
using System.Text;

class GreedyDwarf
{
    static bool IsOutOfTheValley(int x)
    {
        if (x < 0 || x >= valley.Length || isVisited[x])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static int CollectCoins(short[] pattern)
    {
        int x = 0;
        int coins = 0;
        for (int i = 0; !IsOutOfTheValley(x); i++)
        {
            if (i == pattern.Length)
            {
                i = 0;
            }
            coins += valley[x];
            isVisited[x] = true;
            x += pattern[i];
        }
        return coins;
    }

    static short[] valley;
    static bool[] isVisited;
    static void Main()
    {
        int maxCoins = int.MinValue;
        char[] separator = {' ',',' };
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        valley = new short[splittedInput.Length];
        for (int i = 0; i < valley.Length; i++)
        {
            valley[i] = short.Parse(splittedInput[i]);
        }
        ushort m = ushort.Parse(Console.ReadLine());
        short[][] patterns = new short[m][];
        for (int i = 0; i < m; i++)
		{
            isVisited = new bool[valley.Length];
            input = Console.ReadLine();
            splittedInput = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            patterns[i] = new short [splittedInput.Length];
            for (int j = 0; j < patterns[i].Length;j++)
            {
                patterns[i][j] = short.Parse(splittedInput[j]);
            }
            int currentCoins = CollectCoins(patterns[i]);
            if(maxCoins < currentCoins)
            {
                maxCoins = currentCoins;
            }
		}
        Console.WriteLine(maxCoins);
    }
}

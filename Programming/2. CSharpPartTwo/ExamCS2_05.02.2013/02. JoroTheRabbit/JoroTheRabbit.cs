using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JoroTheRabbit
{
    static void SetBestJump(ushort pos)
    {
        for (ushort step = 1; step < terrain.Length; step++)
        {
            short previousJumpValue = -1001;
            ushort jumpCount = 0;
            for (ushort i = pos; terrain[i] > previousJumpValue; )
            {
                jumpCount++;
                previousJumpValue = terrain[i];
                i += step;
                if (i >= terrain.Length)
                {
                    i = (ushort)(i % terrain.Length);
                }
            }
            if (jumpCount > bestJump)
            {
                bestJump = jumpCount;
            }
        }
    }

    static ushort bestJump = 0;

    static short[] terrain;
    static short[] sortedTerrain;

    static void Main()
    {
        char[] separator = { ',', ' ' };
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        terrain = new short[splittedInput.Length];
        sortedTerrain = new short[splittedInput.Length];
        for (ushort i = 0; i < splittedInput.Length; i++)
        {
            terrain[i] = short.Parse(splittedInput[i]);
        }
        Array.Copy(terrain, sortedTerrain, terrain.Length);
        Array.Sort(sortedTerrain);
        for (ushort i = 0; i < terrain.Length; i++)
        {
            if (bestJump >= terrain.Length - Array.BinarySearch(sortedTerrain, terrain[i]))
            {
                continue;
            }
            SetBestJump(i);
        }
        Console.WriteLine(bestJump);
    }
}
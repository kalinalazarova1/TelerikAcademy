using System;

class Program
{
    static long GetCuboidSplits(int[, ,] cuboid)
    {
        long splitCount = 0;
        long sum = 0;
        for (int i = 0; i < cuboid.GetLength(1) - 1; i++)
        {
            for (int j = 0; j < cuboid.GetLength(2); j++)
            {
                for (int k = 0; k < cuboid.GetLength(0); k++)
                {
                    sum += cuboid[k, i, j];
                }
            }
            if (sum == cuboidSum / 2) splitCount++;
        }
        sum = 0;
        for (int i = 0; i < cuboid.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < cuboid.GetLength(1); j++)
            {
                for (int k = 0; k < cuboid.GetLength(2); k++)
                {
                    sum += cuboid[i, j, k];
                }
            }
            if (sum == cuboidSum / 2) splitCount++;
        }
        sum = 0;
        for (int i = 0; i < cuboid.GetLength(2) - 1; i++)
        {
            for (int j = 0; j < cuboid.GetLength(0); j++)
            {
                for (int k = 0; k < cuboid.GetLength(1); k++)
                {
                    sum += cuboid[j, k, i];
                }
            }
            if (sum == cuboidSum / 2) splitCount++;
        } 
        return splitCount;
    }

    static long cuboidSum = 0;

    static void Main()
    {
            char[] separator = { ' ' };
            string[] input = Console.ReadLine().Split(' ');
            int w = int.Parse(input[0]);
            int h = int.Parse(input[1]);
            int d = int.Parse(input[2]);
            int[, ,] cuboid = new int[w, h, d];        
            for (int i = 0; i < h; i++)
            {
                string[] numSequence = Console.ReadLine().Split('|');
                for (int j = 0; j < d; j++)
                {
                    string[] num = numSequence[j].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < w; k++)
                    {
                        cuboid[k, i, j] = int.Parse(num[k]);
                        cuboidSum += cuboid[k, i, j];
                    }
                }
            }
            Console.WriteLine(GetCuboidSplits(cuboid));
    }
}
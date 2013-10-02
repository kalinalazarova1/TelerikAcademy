using System;
using System.Collections.Generic;

class _3DStars
{
    static void Get3DStars(char[, ,] cuboid, int r, int c, int l)
    {
        if (cuboid[r + 1, c, l] == cuboid[r, c, l] &&
            cuboid[r - 1, c, l] == cuboid[r, c, l] &&
            cuboid[r, c + 1, l] == cuboid[r, c, l] &&
            cuboid[r, c - 1, l] == cuboid[r, c, l] &&
            cuboid[r, c, l + 1] == cuboid[r, c, l] &&
            cuboid[r, c, l - 1] == cuboid[r, c, l])
        {
            stars[(int)(cuboid[r, c, l] - 'A')]++;
            totalStars++;
        }
    }

    static int totalStars = 0;

    static int[] stars = new int[26];

    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int w = int.Parse(input[0]);
        int h = int.Parse(input[1]);
        int d = int.Parse(input[2]);
        char[, ,] cuboid = new char[w, h, d];
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
        for (int i = 1; i < h - 1; i++)
        {
            for (int j = 1; j < d - 1; j++)
            {
                for (int k = 1; k < w - 1; k++)
                {
                    Get3DStars(cuboid, k, i, j);
                }
            }
        }
        Console.WriteLine(totalStars);
        for (int i = 0; i < 26; i++)
        {
            if (stars[i] != 0)
            {
                Console.WriteLine("{0} {1}", (char)(i + 'A'), stars[i]);
            }
        }
    }
}

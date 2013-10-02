using System;

class AcademyTasks
{
    static int GetSolvedTasks(int[] pl, int minIndex, int maxIndex)
    {
        if (minIndex > maxIndex)
        {
            return 1 + maxIndex / 2 + (maxIndex % 2 == 0 ? 0 : 1) + (minIndex - maxIndex) / 2 + ((minIndex - maxIndex) % 2 == 0 ? 0 : 1);
        }
        else
        {
            return 1 + minIndex / 2 + (minIndex % 2 == 0 ? 0 : 1) + (maxIndex - minIndex) / 2 + ((maxIndex - minIndex) % 2 == 0 ? 0 : 1);
        }
    }

    static void Main()
    {
        char[] separator = {' ',','};
        string[] input = "96, 246, 257, 128, 170, 52, 212, 270, 79, 152, 249, 110, 88, 142, 263, 70, 6, 99, 1, 175, 11, 113, 197, 203, 269, 207, 166, 175, 255".Split(separator, StringSplitOptions.RemoveEmptyEntries);
        int[] pl = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            pl[i] = int.Parse(input[i]);
        }
        int variety = 251;// int.Parse(Console.ReadLine());
        int max = pl[0];
        int min = pl[0];
        int maxIndex = 0;
        int minIndex = 0;
        for (int i = 0; i < pl.Length; i++)
        {
            if (pl[i] < min)
            {
                min = pl[i];
                minIndex = i;
            }
            if (pl[i] > max)
            {
                max = pl[i];
                maxIndex = i;
            }
            if (max - min >= variety)
            {
                Console.WriteLine(GetSolvedTasks(minIndex, maxIndex));
                return;
            }
        }
        Console.WriteLine(pl.Length);
    }
}

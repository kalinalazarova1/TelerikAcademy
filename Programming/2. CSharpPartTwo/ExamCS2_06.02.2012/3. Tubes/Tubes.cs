using System;

class Tubes
{
    static void Main()
    {
        long allTubes = 0;
        long n = long.Parse(Console.ReadLine());
        long m = long.Parse(Console.ReadLine());
        long[] tubes = new long[n];
        for (int i = 0; i < n; i++)
        {
            tubes[i] = long.Parse(Console.ReadLine());
            allTubes += tubes[i];
        }
        if (m > allTubes)
        {
            Console.WriteLine(-1);
            return;
        }
        long max = (allTubes / m);
        long min = 1;
        while (min <= max)
        {
            long mid = (min + max) / 2;
            long cutTubesCount = 0;
            for (int i = 0; i < n; i++)
            {
                cutTubesCount += tubes[i] / mid;
            }
            if (cutTubesCount >= m)
            {
                min = mid + 1;
            }
            else if (cutTubesCount < m)
            {
                max = mid - 1;
            }
        }
        Console.WriteLine(max);
    }
}

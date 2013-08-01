using System;

class EnglishFlag
{
    static void Main()
    {
        int n;
        n = Int32.Parse(Console.ReadLine());
        char[,] ukFlag = new char[n, n];
        int r = 0;
        int c = 0;
        for (r = 0; r < n; r++)
        {
            for (c = 0; c < n; c++)
            {
                ukFlag[r, c] = '.';
            }
        }
        c = 0;
        for(r = 0; r < n; r++, c++)
        {
            ukFlag[r, c] = '\\';
        }
        c = n - 1;
        for(r = 0; r < n; r++, c--)
        {
            ukFlag[r, c] = '/';
        }
        r = 0;
        for (c = n / 2; r < n; r++)
        {
            ukFlag[r, c] = '|';
        }
        c = 0;
        for (r = n / 2; c < n; c++)
        {
            ukFlag[r, c] = '-';
        }
        ukFlag[n / 2, n / 2 ] = '*';
        for (r = 0; r < n; r++)
        {
            for (c = 0; c < n; c++)
            {
                Console.Write(ukFlag[r, c]);
            }
            Console.WriteLine();
        }
    }
}

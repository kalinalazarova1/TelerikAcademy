using System;
using System.Collections;

class OddNumberv2
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        long[] number = new long[n];
        for (uint i = 0; i < n; i++)
        {
            number[i] = long.Parse(Console.ReadLine());
        }
        Array.Sort(number);
        for (int i = 0; i < n; i++)
        {
            long tempNumber = number[i];
            uint numberCount = 1;
            while (i < n - 1 && tempNumber == number[i + 1])
            {
                numberCount++;
                i++;
            }
            if (i == n) i--;
            if ((numberCount & 1) == 1)
            {
                Console.WriteLine(number[i]);
                break;
            }
        }
    }
}

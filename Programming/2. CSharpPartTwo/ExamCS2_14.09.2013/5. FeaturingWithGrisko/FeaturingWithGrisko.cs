using System;

class FeaturingWithGrisko
{
    static int combCount = 0;

    static int[] usedCount;

    static void GetComb(char[] comb, int start)
    {
        if (start >= comb.Length)
        {
            combCount++;
            return;
        }
        for (int i = 0; i < usedCount.Length; i++)
        {
            if ((start == 0 || comb[start - 1] != (char)(i + 'a')) && usedCount[i] > 0)
            {
                comb[start] = (char)(i + 'a');
                usedCount[i]--;
                GetComb(comb, start + 1);
                usedCount[i]++;
            }
        }
    }

    static void Main()
    {
        usedCount = new int[26];
        string letters = Console.ReadLine();
        for (int i = 0; i < letters.Length; i++)
        {
            usedCount[letters[i] - 'a']++;
        }
        char[] comb = new char[letters.Length];
        GetComb(comb, 0);
        Console.WriteLine(combCount);
    }
}
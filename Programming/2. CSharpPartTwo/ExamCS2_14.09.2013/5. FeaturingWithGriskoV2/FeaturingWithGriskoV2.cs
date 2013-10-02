using System;
using System.Text;

class FeaturingWithGriskoV2
{
    static int combCount = 0;

    static int[] usedCount = new int[26];

    static void GetComb(char[] letters, char[] comb, int start)
    {
        if (start >= comb.Length)
        {
            combCount++;
            return;
        }
        for (int i = 0; i < letters.Length; i++)
        {
            if ((start == 0 || comb[start - 1] != letters[i]) && usedCount[letters[i] - 'a'] > 0)
            {
                comb[start] = letters[i];
                usedCount[letters[i] - 'a']--;
                GetComb(letters, comb, start + 1);
                usedCount[letters[i] - 'a']++;
            }
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();
        for (int i = 0; i < input.Length; i++)
        {
            usedCount[input[i] - 'a']++;
        }
        StringBuilder letters = new StringBuilder();
        for (int i = 0; i < usedCount.Length; i++)
        {
            if (usedCount[i] > 0)
            {
                letters.Append((char)(i + 'a'));
            }
        }
        char[] posLetters = letters.ToString().ToCharArray();
        char[] comb = new char[input.Length];
        GetComb(posLetters, comb, 0);
        Console.WriteLine(combCount);
    }
}
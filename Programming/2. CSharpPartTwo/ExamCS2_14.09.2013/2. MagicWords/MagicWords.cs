using System;
using System.Text;

class MagicWords
{
    static void Print(string[] words, int[] positions, int maxLen)
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < maxLen; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (i >= words[positions[j]].Length) continue;
                output.Append(words[positions[j]][i]);
            }
        }
        Console.WriteLine(output);
    }

    static void Swap(int[] arr, int pos1, int pos2)
    {
        int temp = arr[pos1];
        arr[pos1] = arr[pos2];
        arr[pos2] = temp;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] words = new string[n];
        int maxLen = 0;
        int[] positions = new int[n];
        for (int i = 0; i < n; i++)
        {
            words[i] = Console.ReadLine();
            positions[i] = i;
            if (maxLen < words[i].Length)
            {
                maxLen = words[i].Length;
            }
        }
        for (int i = 0; i < n; i++)
        {
            int newPos = words[positions[i]].Length % (n + 1);
            if (newPos > i + 1)
            {
                for (int j = 0; j < Math.Abs(newPos - i - 1); j++)
                {
                    Swap(positions, i + j, i + 1 + j);
                }
            }
            else if(newPos < i)
            {
                for (int j = 0; j < Math.Abs(newPos - i); j++)
                {
                    Swap(positions, i - j, i - 1 - j);
                }
            }
        }
        Print(words, positions, maxLen);
    }
}

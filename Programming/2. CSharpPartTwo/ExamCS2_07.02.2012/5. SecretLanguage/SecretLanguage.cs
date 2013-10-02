using System;
using System.Text;

class SecretLanguage
{
    static long Sum(string s)
    {
        long sum = 0; 
        for (int i = 0; i < s.Length; i++)
        {
            sum += (long)s[i];
        }
        return sum;
    }

    static bool IsSameWord(string first, long sumFirst, string second, long sumSecond)
    {
        if (first.Length != second.Length) return false;
        if (sumFirst != sumSecond) return false;
        for (int i = 0; i < first.Length; i++)
        {
            if (second.IndexOf(first[i]) < 0) return false;
            if (first.IndexOf(second[i]) < 0) return false;
        }
        return true;
    }

    static int GetCost(string original, string s)
    {
        int cost = 0;
        for (int i = 0; i < original.Length; i++)
        {
            if (original[i] != s[i]) cost++;
        }
        return cost;
    }

    static void GetSentence(string sentence, int start)
    {
        if (start >= sentence.Length)
        {
            int currCost = GetCost(originalSentence, sentence);
            if (currCost < answerCost || answerCost == -1)
            {
                //Console.WriteLine(sentence);
                answerCost = currCost;
            }
            return;
        }
        StringBuilder newSen = new StringBuilder();
        long curSum = 0;
        for (int i = start; i < sentence.Length; i++)
        {
            newSen.Append(sentence[i]);
            curSum += (long)sentence[i];
            for (int j = 0; j < words.Length; j++)
            {
                if (IsSameWord(words[j], sumWords[j], newSen.ToString(), curSum))
                {
                    newSen.Clear();
                    if (start > 0)
                    {
                        newSen.Append(sentence.Substring(0, start));
                    }
                    newSen.Append(words[j]);
                    newSen.Append(sentence.Substring(i + 1));
                    GetSentence(newSen.ToString(), i + 1);
                    newSen.Clear();
                    newSen.Append(sentence.Substring(start, i - start + 1));
                }
            }
        }
    }

    static int answerCost = -1;
    static string originalSentence;
    static string[] words;
    static long[] sumWords;

    static void Main()
    {
        //using (System.IO.StreamReader reader = new System.IO.StreamReader("test13.txt"))
        //{
            char[] separator = { ' ', '\"', ',' };
            originalSentence = Console.ReadLine();
            words = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            sumWords = new long[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                sumWords[i] = Sum(words[i]);
            }
            GetSentence(originalSentence, 0);
            Console.WriteLine(answerCost < 0 ? -1 : answerCost);
        //}
    }
}

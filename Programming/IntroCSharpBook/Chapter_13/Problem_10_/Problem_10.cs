using System;
using System.Text;

class Problem_10
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string keyword = "in";
        text = text.ToLower();
        string[] sentences = text.Split('.');
        for (int i = 0; i < sentences.Length; i++)
        {
            int wordStartIndex = 0;
            for (int j = 0; j < sentences[i].Length; j++)
            {
                wordStartIndex = sentences[i].IndexOf(keyword, wordStartIndex + keyword.Length);
                if (wordStartIndex != -1)
                {
                    if (!Char.IsLetter(sentences[i][wordStartIndex - 1]))
                    {
                        if ((wordStartIndex + keyword.Length == sentences[i].Length) || !Char.IsLetter(sentences[i][wordStartIndex + keyword.Length]))
                        {
                            sentences[i] = sentences[i].Trim();
                            Console.WriteLine("{0}{1}.", Char.ToUpper(sentences[i][0]), sentences[i].Substring(1));
                            break;
                        }
                    }

                }
            }
        }
    }
}

using System;
using System.Text;
using System.Text.RegularExpressions;

    class Problem_21
    {
        static string ReverseString(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        static void Main()
        {
            string text = "The palindrom is a word that is the same when is read backwards. For example: level or pop. Of course the total list could be quite long especially when include my word appa and laval. Laval actually means nothing.";
            char[] separator = {' ', '.', ':', ',', ';', '!', '?', '"'};
            text = text.ToLower();
            string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                text = text.Trim();
                if (ReverseString(word) == word && word.Length > 1)
                {
                    Console.WriteLine(word);
                }
            }

        }
    }

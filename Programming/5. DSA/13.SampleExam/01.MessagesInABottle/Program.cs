namespace _01.MessagesInABottle
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        internal static void Main()   
        {
            var answers = new Queue<Message>();
            var message = Console.ReadLine();
            answers.Enqueue(new Message(message, string.Empty));
            var cipherString = Console.ReadLine();
            var cipher = new Dictionary<string, char>();
            ParseCipher(cipherString, cipher);
            var results = new SortedSet<string>();
            while (answers.Count > 0)
            {
                var current = answers.Dequeue();
                for (int i = 1; i <= current.Original.Length; i++)
                {
                    if (GetLetter(i, current.Original, cipher) != null)
                    {
                        if (i == current.Original.Length)
                        {
                            results.Add(current.Decoded + GetLetter(i, current.Original, cipher));
                        }
                        else
                        {
                            var newOriginal = current.Original.Substring(i);
                            var newDecoded = current.Decoded + GetLetter(i, current.Original, cipher);
                            answers.Enqueue(new Message(newOriginal, newDecoded));
                        }
                    }
                }
            }

            Console.WriteLine(results.Count);
            Console.WriteLine(string.Join(Environment.NewLine, results));
        }

        private static char? GetLetter(int len, string message, Dictionary<string, char> cipher)
        {
            if (cipher.ContainsKey(message.Substring(0, len)))
            {
                return cipher[message.Substring(0, len)];
            }

            return null;
        }

        private static void ParseCipher(string cipherString, Dictionary<string, char> cipher)
        {
            var currValue = string.Empty;
            var currKey = cipherString[0];
            for (int i = 1; i < cipherString.Length; i++)
            {
                if (char.IsLetter(cipherString[i]))
                {
                    cipher.Add(currValue, currKey);
                    currValue = string.Empty;
                    currKey = cipherString[i];
                }
                else
                {
                    currValue += cipherString[i];
                }
            }

            cipher.Add(currValue, currKey);
        }
    }
}

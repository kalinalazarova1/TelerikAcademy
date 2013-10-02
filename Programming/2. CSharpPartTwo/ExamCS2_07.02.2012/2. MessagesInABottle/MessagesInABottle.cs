using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MessagesInABottle
{
    static void GetMessage(string input, int start, Dictionary<string, char> cipher, List<string> answers)
    {
        if (start >= input.Length)
        {
            answers.Add(input);
            return;
        }
        StringBuilder newMess = new StringBuilder();
        for (int i = start; i < input.Length; i++)
        {
            newMess.Append(input[i]);
            char newChar;
            if (cipher.TryGetValue(newMess.ToString(), out newChar))
            {
                StringBuilder newMessMod = new StringBuilder();
                if (start > 0)
                {
                    newMessMod.Append(input.Substring(0, start));
                }
                newMessMod.Append(newChar);
                if(i <= input.Length - 2)
                {
                    newMessMod.Append(input.Substring(i + 1));
                }
                GetMessage(newMessMod.ToString(), start + 1, cipher, answers);
            }
            else if (i == input.Length - 1)
            {
                return;
            }
        }
    }

    static void Main()
    {
        List<string> answers = new List<string>();
        Dictionary<string, char> cipher = new Dictionary<string,char>();
        string input = Console.ReadLine();
        string cipherInput = Console.ReadLine();
        for (int i = 0; i < cipherInput.Length;)
        {
            StringBuilder key = new StringBuilder();
            char value = cipherInput[i++];
            while(!Char.IsLetter(cipherInput[i]))
            {
                key.Append(cipherInput[i]);
                i++;
                if (i == cipherInput.Length)
                {
                    break;
                }
            }
            cipher.Add(key.ToString(), value);
        }
        GetMessage(input, 0, cipher, answers);
        Console.WriteLine(answers.Count);
        answers.Sort();
        foreach (string answer in answers)
        {
            Console.WriteLine(answer);
        }
    }
}

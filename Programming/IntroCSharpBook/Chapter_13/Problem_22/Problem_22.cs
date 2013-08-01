using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Problem_22
{
    static void Main()
    {
        string text = "The palindrom is a word that is the same when is read backwards. For example: level or pop. Of course the total list could be quite long especially when include my word appa and laval. Laval actually means nothing.";
        text = text.ToLower();
        uint[] alphabet = new uint[27];
        for (int i = 0; i < text.Length; i++)
        {
            if(Char.IsLetter(text[i]))
            {
                alphabet[(int)(text[i] - 'a')]++;
            }
        }
        for (int i = 0; i < alphabet.Length; i++)
		{
            if(alphabet[i] != 0)
            {
                Console.WriteLine("Letter {0} is found {1} times.", (char)(i + 'a'), alphabet[i]);
            }
		}
    }
}

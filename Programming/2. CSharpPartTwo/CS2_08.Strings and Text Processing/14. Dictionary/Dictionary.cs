//14.  A dictionary is stored as a sequence of text lines containing words and their explanations. 
//Write a program that enters a word and translates it by using the dictionary.
//Sample dictionary:
//.NET - platform for applications from Microsoft
//CLR - managed execution environment for .NET
//namespace - hierarchical organization of classes

using System;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {
        bool isFound = false;
        string[] input = { ".NET – platform for applications from Microsoft", "CLR – managed execution environment for .NET", "namespace – hierarchical organization of classes" };
        string[,] dictionary = new string[input.Length, 2];
        for (int i = 0; i < input.Length; i++)
        {
            int index = input[i].IndexOf(" – ");
            dictionary[i, 0] = input[i].Substring(0, index);
            dictionary[i, 0] = dictionary[i, 0].Trim();
            dictionary[i, 1] = input[i].Substring(index + 2);
            dictionary[i, 1] = dictionary[i, 1].Trim();
        }
        Console.WriteLine("Please input a word:");
        string keyword = Console.ReadLine();
        for (int i = 0; i < dictionary.GetLength(0); i++)
        {
            if (dictionary[i, 0].ToLower() == keyword.ToLower())
            {
                Console.WriteLine("{0}{1}", Char.ToUpper(dictionary[i, 1][0]), dictionary[i, 1].Substring(1));
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            Console.WriteLine("The word is not in the dictonary!");
        }
    }

    /*static void Main()            //this version uses IDictionary<> - sorted dictionary
    {
        string input = ".NET – platform for applications from Microsoft\nCLR – managed execution environment for .NET\nnamespace – hierarchical organization of classes";
        char[] separator = { '\n', '–' };
        string[] splittedInput = input.Split(separator);
        IDictionary<string, string> dictionary = new SortedDictionary<string, string>();
        for (int i = 0; i < splittedInput.Length; i += 2)
        {
            dictionary.Add(splittedInput[i].Trim().ToLower(), splittedInput[i + 1].Trim());
        }
        Console.WriteLine("Please input a word:");
        string keyword = Console.ReadLine().ToLower();
        string explanation = string.Empty;
        if (dictionary.TryGetValue(keyword, out explanation))
        {
            Console.WriteLine("{0}{1}", Char.ToUpper(explanation[0]), explanation.Substring(1));
        }
        else
        {
            Console.WriteLine("The word is not in the dictonary!");
        }
    }*/
}

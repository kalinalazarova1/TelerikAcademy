using System;
using System.Text;

class Problem_15
{
    static void Main()
    {
        bool isFound = false;
        string[] input = { ".NET – platform for applications from Microsoft", "CLR – managed execution environment for .NET", "namespace – hierarchical organization of classes" };
        string[,] dictionary = new string[input.Length,2];
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
            if (dictionary[i, 0] == keyword)
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
}

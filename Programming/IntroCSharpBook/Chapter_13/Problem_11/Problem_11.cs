using System;
using System.Text;

class Problem_11
{
    static void Main()
    {
        string input = "Microsoft announced its next generation C# compiler today. It uses advanced parser and special optimizer for the Microsoft CLR.";
        string forbiddenWords = "C#,CLR,Microsoft";
        string[] forbidden = forbiddenWords.Split(',');
        int forbiddenWordIndex = 0;
        for (int j = 0; j < forbidden.Length; j++) 
        {
            for (int i = 0; i < input.Length; i++)
            {
                forbiddenWordIndex = input.IndexOf(forbidden[j],forbiddenWordIndex + forbidden[j].Length);
                if (forbiddenWordIndex != -1)
                {
                    input = input.Replace(forbidden[j], new string('*', forbidden[j].Length));
                }
            }
        }
        Console.WriteLine(input);
    }
}

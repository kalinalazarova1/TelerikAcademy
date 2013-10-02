using System;
using System.Text;
using System.Collections.Generic;

class PHPVariables
{
    static void Main()
    {
        bool isMultiComment = false;
        bool isSingleString = false;
        bool isDoubleString = false;
        List<string> vars = new List<string>();
        //using (System.IO.StreamReader reader = new System.IO.StreamReader("test8.txt"))
        //{
        string input = Console.ReadLine();
        StringBuilder varName = new StringBuilder();
        while (input != "?>")
        {
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '/':
                        if (!isSingleString && !isDoubleString && !isMultiComment && i != input.Length - 1 && input[i + 1] == '/') i = input.Length - 1;
                        else if (!isSingleString && !isDoubleString && i != input.Length - 1 && input[i + 1] == '*') isMultiComment = true;
                        else if (!isSingleString && !isDoubleString && i != 0 && input[i - 1] == '*') isMultiComment = false;
                        break;
                    case '#':
                        if (!isSingleString && !isDoubleString && !isMultiComment) i = input.Length - 1;
                        break;
                    case '"':
                        if (!isMultiComment && !isDoubleString && !isSingleString) isDoubleString = true;
                        else if (!isMultiComment && isDoubleString && (i == input.Length - 1 || i != input.Length - 1 && input[i - 1] != '\\')) isDoubleString = false;
                        break;
                    case '\'':
                        if (!isMultiComment && !isDoubleString && !isSingleString) isSingleString = true;
                        else  if (!isMultiComment && !isDoubleString && (i == 0 || i != 0 && input[i - 1] != '\\' || i > 1 && input[i - 1] == '\\' && input[i - 2] == '\\')) isSingleString = false;
                        break;
                    case '$':
                        if (!isMultiComment && !isSingleString && !isDoubleString)
                        {
                            i++;
                            if (i >= input.Length - 1)
                            {
                                input = Console.ReadLine();
                                i = 0;
                            }
                            while (Char.IsLetterOrDigit(input[i]) || input[i] == '_')
                            {
                                varName.Append(input[i]);
                                if (i == input.Length - 1)
                                {
                                    input = Console.ReadLine();
                                    i = 0;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                            if (vars.IndexOf(varName.ToString()) < 0 && varName.ToString().Length > 0)
                            {
                                vars.Add(varName.ToString());
                            }
                            varName.Clear();
                        }
                        else if (!isMultiComment && (isSingleString || isDoubleString) && (i == 0 || (i != 0 && input[i - 1] != '\\') || i > 1 && input[i - 1] == '\\' && input[i - 2] == '\\'))
                        {
                            i++;
                            while (Char.IsLetterOrDigit(input[i]) || input[i] == '_')
                            {
                                varName.Append(input[i]);
                                if (i == input.Length - 1)
                                {
                                    input = Console.ReadLine();
                                    i = 0;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                            if (vars.IndexOf(varName.ToString()) < 0 && varName.ToString().Length > 0)
                            {
                                vars.Add(varName.ToString());
                            }
                            varName.Clear();
                        }
                        break;
                    default: break;
                }
            }
            input = Console.ReadLine();
        }
        vars.Sort(StringComparer.Ordinal);
        Console.WriteLine(vars.Count);
            foreach (string name in vars)
            {
                Console.WriteLine(name);
            }
        //}
    }
}
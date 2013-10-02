using System;
using System.Text;
using System.Collections.Generic;

class CSharpCleanCode
{
    static void Main()
    {
        using(System.IO.StreamReader reader = new System.IO.StreamReader("test.txt"))
        {
            List<StringBuilder> all = new List<StringBuilder>();
            bool isOpenComment = false;
            bool isOpenString = false;
            bool isQuoted = false;
            StringBuilder currentLine = new StringBuilder();
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (i == 593)
                {
                    int k = 5;
                }
                string line = reader.ReadLine();
                StringBuilder newLine = new StringBuilder();
                if (isOpenComment)
                {
                    newLine.Append(currentLine);
                }
                for (int j = 0; j < line.Length; j++)
                {
                    if (j == 11)
                    {
                        int k = 3;
                    }
                    if (line[j] == '"')
                    {
                        if (!isOpenString && !isOpenComment)
                        {
                            if (j == 0 || j != 0 && line[j - 1] != '\\')
                            {
                                if (j == 0 || j == line.Length - 1 || line[j - 1] != '\'' || line[j + 1] != '\'')
                                {
                                    isOpenString = true;
                                    if (j != 0 && line[j - 1] == '@')
                                    {
                                        isQuoted = true;
                                    }
                                }
                            }
                            newLine.Append(line[j]);
                        }
                        else if (isOpenString && !isOpenComment)
                        {
                            if (j != 0 && line[j - 1] != '\\' && !isQuoted || j == 0)
                            {
                                isOpenString = false;
                            }
                            else if (j != 0 && line[j - 1] != '\\' && isQuoted)
                            {
                                if (j != line.Length - 1 && line[j + 1] != '\"')
                                {
                                    isOpenString = false;
                                    isQuoted = false;
                                }
                                else if (j != line.Length - 1 && line[j + 1] == '\"')
                                {
                                    newLine.Append(line[j]);
                                    j++;
                                }
                            }
                            newLine.Append(line[j]);
                        }
                    }
                    else if (j != line.Length - 1 && line[j] == '/' && line[j + 1] == '/')
                    {
                        if (isOpenString)
                        {
                            newLine.Append(line[j]);    
                        }
                        else if (isOpenComment)
                        {
                            continue;
                        }
                        else if (j < line.Length - 3 && line[j + 2] == '/' && line[j + 3] != '/')
                        {
                            newLine.Append(line[j]);
                            newLine.Append(line[j + 1]);
                            newLine.Append(line[j + 2]);
                            j += 2;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (j != line.Length - 1 && line[j] == '/' && line[j + 1] == '*')
                    {
                        if (isOpenString)
                        {
                            newLine.Append(line[j]);
                        }
                        else
                        {
                            isOpenComment = true;
                        }
                    }
                    else if (j != line.Length - 1 && line[j] == '*' && line[j + 1] == '/')
                    {
                        if (isOpenString)
                        {
                            newLine.Append(line[j]);
                        }
                        else
                        {
                            isOpenComment = false;
                            if (j != line.Length - 1)
                            {
                                j++;
                            }
                        }
                    }
                    else
                    {
                        if (!isOpenComment)
                        {
                            newLine.Append(line[j]);
                        }
                    }
                }
                if (newLine.ToString().Trim() != string.Empty && !isOpenComment)
                {
                    all.Add(newLine);
                }
                if (isOpenComment)
                {
                    currentLine = newLine;
                }
            }
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("out.txt"))
            {
                foreach (var codeLine in all)
                {
                    writer.WriteLine(codeLine);
                }
            }
            using (System.IO.StreamReader outReader = new System.IO.StreamReader("out.txt"))
            {
                using (System.IO.StreamReader out1Reader = new System.IO.StreamReader("out1.txt"))
                {
                    string line = outReader.ReadLine();
                    string line1 = out1Reader.ReadLine();
                    for (int i = 0; line != null || line1 != null; i++, line = outReader.ReadLine(), line1 = out1Reader.ReadLine())
                    {
                        if (line != line1)
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }
    }
    }
}

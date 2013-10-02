using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FakeTextMarkupLanguage
{
    static string ReverseString(string s)
    {
        if (s == "") return s;
        StringBuilder sb = new StringBuilder(s.Length);
        for (int i = s.Length - 1; i >= 0; i--)
        {
            sb.Append(s[i]);
        }
        return sb.ToString();
    }

    static string Manipulate(string s)
    {
        if (s == "") return s;
        StringBuilder sb = new StringBuilder(s);

        switch (tags.Peek().ToString())
        {
            case "toggle":
                {
                    for (ushort i = 0; i < sb.Length; i++)
                    {
                        if (Char.IsLower(sb[i]))
                        {
                            sb[i] = Char.ToUpper(sb[i]);
                        }
                        else
                        {
                            sb[i] = Char.ToLower(sb[i]);
                        }
                    }
                    s = sb.ToString();
                    break;
                }
            case "lower":
                {
                    s = s.ToLower();
                    break;
                }
            case "upper":
                {
                    s = s.ToUpper();
                    break;
                }
            case "del":
                {
                    s = "";
                    break;
                }
            case "rev":
                {
                    s = ReverseString(s.ToString());
                    break;
                }
        }
        return s;
    }

    static Stack<string> tags = new Stack<string>();

    static void Main()
    {
        Stack<string> texts = new Stack<string>();
        bool isOpenTag = false;
        StringBuilder finalText = new StringBuilder();
        ushort n = ushort.Parse(Console.ReadLine());
        StringBuilder lines = new StringBuilder(n);
        for (ushort i = 0; i < n; i++)
        {
            lines.Append(Console.ReadLine());
            lines.Append('\n');
        }
        StringBuilder currTag = new StringBuilder(7);
        StringBuilder text = new StringBuilder();
        for (int j = 0; j < lines.Length; j++)
        {
            if (lines[j] == '<')
            {
                if (tags.Count == 0)
                {
                    finalText.Append(text);
                    text.Clear();
                }
                texts.Push(text.ToString());
                text.Clear();
                isOpenTag = true;
                continue;
            }
            else if (lines[j] == '>')
            {
                isOpenTag = false;
                tags.Push(currTag.ToString());
                currTag.Clear();
                continue;
            }
            if (isOpenTag)
            {
                if (lines[j] == '/')
                {
                    j++;
                    while (lines[j] != '>')
                    {
                        j++;
                    }
                    string temp = Manipulate(texts.Pop().ToString());
                    text.Append(texts.Pop());
                    text.Append(temp);
                    tags.Pop();
                    isOpenTag = false;
                }
                else
                {
                    currTag.Append(lines[j]);
                }
            }
            else
            {
                text.Append(lines[j]);
            }
        }
        if (text.ToString() != "" && tags.Count == 0)
        {
            finalText.Append(text);
            text.Clear();
        }
        Console.WriteLine(finalText);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CSharpBrackets
{
    static string RemoveRepeatedWhitespaces(string s)
    {
        bool isUinque = true;
        StringBuilder newString = new StringBuilder(s.Length);
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ' && isUinque )
            {
                newString.Append(s[i]);
                isUinque = false;
            }
            else if (s[i] != ' ')
            {
                newString.Append(s[i]);
                isUinque = true;
            }
            else
            {
                continue;
            }
        }
        return newString.ToString();
    }

    static string GetTotalIdent(string id, ulong count)
    {
        StringBuilder ident = new StringBuilder();
        for (ulong i = 0; i < count; i++)
        {
            ident.Append(id);
        }
        return ident.ToString();
    }

    static void Main()
    {
        ulong identCount = 0;
        ushort n = ushort.Parse(Console.ReadLine());
        List<string> lines = new List<string>();
        string identionString = Console.ReadLine();
        for (int i = 0; i < n; i++)
        {
            char[] separator = {'б'};
            string tempInput = Console.ReadLine();
            tempInput = tempInput.Replace("{", "б{б");
            tempInput = tempInput.Replace("}", "б}б");
            string[] newLines = tempInput.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < newLines.Length; j++)
            {
                lines.Add(RemoveRepeatedWhitespaces(newLines[j]).Trim());
            }
        }
        foreach (var line in lines)
        {
            if (line == "{")
            {
                Console.WriteLine("{0}{1}", GetTotalIdent(identionString, identCount), line);
                identCount++;
            }
            else if (line == "}")
            {
                identCount--;
                Console.WriteLine("{0}{1}", GetTotalIdent(identionString, identCount), line);
            }
            else if (line == "")
            {
                continue;
            }
            else
            {
                Console.WriteLine("{0}{1}", GetTotalIdent(identionString, identCount), line);
            }
        }
    }
}

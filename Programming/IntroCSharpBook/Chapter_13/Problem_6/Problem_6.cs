using System;
using System.Text;

class Problem_6
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        StringBuilder sbText = new StringBuilder();
        int startTag = text.IndexOf("<upcase>", 0);

        if (startTag == -1)
        {
            sbText.Append(text);
        }
        else
        {
            sbText.Append(text.Substring(0, startTag));
            int endTag = text.IndexOf("</upcase>", startTag + 8);
            sbText.Append(text.Substring(startTag + 8, endTag - startTag - 8).ToUpper());
            while (true)
            {
                startTag = text.IndexOf("<upcase>", endTag + 9);
                if (startTag == -1)
                {
                    break;
                }
                sbText.Append(text.Substring(endTag + 9, startTag - endTag - 9));
                endTag = text.IndexOf("</upcase>", startTag + 8);
                sbText.Append(text.Substring(startTag + 8, endTag - startTag - 8).ToUpper());
            }
            sbText.Append(text.Substring(endTag + 9, text.Length - endTag - 9));  
        }
        Console.WriteLine(sbText);
    }
}

//5. You are given a text. Write a program that changes the text in all regions surrounded 
//by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
//We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//The expected result:
//We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Text;

    class UpperCaseTag
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

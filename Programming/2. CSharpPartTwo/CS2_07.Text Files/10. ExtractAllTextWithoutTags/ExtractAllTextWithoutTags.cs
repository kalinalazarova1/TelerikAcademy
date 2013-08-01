//10. Write a program that extracts from given XML file all the text without the tags. Example:
//<?xml version="1.0"?><student><name>Pesho</name>
//<age>21</age><interests count="3"><interest>
//Games</interest><interest>C#</interest><interest>
//Java</interest></interests></student>

using System;
using System.IO;
using System.Text;

    class ExtractAllTextWithoutTags
    {
        static string RemoveTags(string inputText)
        {
            StringBuilder outputText = new StringBuilder();
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == '<')
                {
                    while (inputText[i] != '>')
                    {
                        i++;
                    }
                }
                else
                {
                    outputText.Append(inputText[i]);
                }
            }
            return outputText.ToString();
        }

        static void Main()
        {
            using (StreamReader reader = new StreamReader("test.txt"))
            {
                Console.WriteLine(RemoveTags(reader.ReadToEnd()));
            }
        }
    }

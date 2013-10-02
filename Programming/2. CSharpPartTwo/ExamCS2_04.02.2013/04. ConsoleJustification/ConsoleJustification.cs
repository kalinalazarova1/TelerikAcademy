using System;
using System.Text;

    class ConsoleJustification
{
    static void Main()
    {
        char[] separator = {' '};
        ushort n = ushort.Parse(Console.ReadLine());
        ushort w = ushort.Parse(Console.ReadLine());
        string[] words;
        bool isLast = false;
        StringBuilder text = new StringBuilder();
        for (ushort i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            text.Append(line);
            text.Append(' ');
        }
        words = text.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder justLine = new StringBuilder(w);
        for (ushort i = 0; i < words.Length; i++)
        {
            if (!isLast && ((justLine.Length > 0 && words[i].Length + 1 + justLine.Length <= w) || (justLine.Length == 0 && words[i].Length <= w)))
            {
                if (justLine.Length != 0)
                {
                    justLine.Append(' ');
                }
                justLine.Append(words[i]);
                if (i == words.Length - 1 && words[i].Length != justLine.Length)
                {
                    short spaceIndex = - 2;
                    ushort counter = 1;
                    while (w > justLine.Length)
                    {
                        spaceIndex = (short)(justLine.ToString().IndexOf(' ', spaceIndex + 1 + counter));
                        if (spaceIndex == -1)
                        {
                            spaceIndex--;
                            counter++;
                            continue;
                        }
                        justLine.Insert(spaceIndex, ' ');
                    }
                }
            }
            else
            {
            if (justLine.Length != words[i - 1].Length)
                {
                    short spaceIndex = - 2;
                    ushort counter = 1;
                    while (w > justLine.Length)
                    {
                        spaceIndex = (short)(justLine.ToString().IndexOf(' ', spaceIndex + 1 + counter));
                        if (spaceIndex == -1)
                        {
                            spaceIndex = (short)-(counter + 1);
                            counter++;
                            continue;
                        }
                        justLine.Insert(spaceIndex, ' ');
                    }
                }
                Console.WriteLine(justLine);
                justLine.Clear();
                i--;
            }
        }
        Console.WriteLine(justLine);
    }
}

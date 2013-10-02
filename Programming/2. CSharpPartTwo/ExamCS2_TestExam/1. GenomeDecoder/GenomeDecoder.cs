using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GenomeDecoder
{
    static string DecodeGemone(string coded)
    {
        StringBuilder decoded = new StringBuilder();
        for (int i = 0; i < coded.Length; i++)
        {
            if (Char.IsLetter(coded[i]))
            {
                decoded.Append(coded[i]);
            }
            else
            {
                StringBuilder count = new StringBuilder();
                while (Char.IsDigit(coded[i]))
                {
                    count.Append(coded[i]);
                    i++;
                }
                for (int j = 0; j < int.Parse(count.ToString()); j++)
                {
                    decoded.Append(coded[i]);   
                }
            }
        }
        return decoded.ToString();
    }

    static void Main()
    {
        bool isEnd = false;
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        string decodedGenome = DecodeGemone(Console.ReadLine());
        int lineNumber = 0;
        for (int k = 0; k < decodedGenome.Length;)
        {
            lineNumber++;
            StringBuilder line = new StringBuilder();
            line.Append(lineNumber.ToString().PadLeft((decodedGenome.Length / n + (decodedGenome.Length % n == 0 ? 0 : 1)).ToString().Length));
            line.Append(' ');
            for (int i = 0; i < n / m + (n % m == 0 ? 0 : 1); i++)
            { 
                for (int j = 0; j < m; j++, k++)
                {
                    if (k >= decodedGenome.Length)
                    {
                        isEnd = true;
                        break;
                    }
                    else if (i == n / m && j >= n % m)
                    {
                        break;
                    }
                    line.Append(decodedGenome[k]);
                }
                if (!isEnd && i != n / m + (n % m == 0 ? 0 : 1) - 1)
                {
                    line.Append(' ');
                }
            }
            Console.WriteLine(line);
        }
    }
}

using System;
using System.Text;
using System.Linq;

class DecodeAndDecrypt
{
    static string Encrypt(string mess, string ciph)
    {
        char[] message = mess.ToCharArray();
        char[] cipher = ciph.ToCharArray();
        int j = 0;
        for (int i = 0; i < Math.Max(message.Length, cipher.Length) && j < Math.Max(message.Length, cipher.Length); i++, j++)
        {
            if (i == message.Length) i = 0;
            if (j == cipher.Length) j = 0;
            message[i] = (char)(((message[i] - 'A') ^ (cipher[j] - 'A')) + 'A');
        }
        return string.Join(string.Empty, message);
    }

    static string Decode(string coded)
    {
        StringBuilder decoded = new StringBuilder();
        for (int i = 0; i < coded.Length; i++)
        {
            if (!Char.IsDigit(coded[i]))
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

    static string input;

    static void Main()
    {
        input = Console.ReadLine();
        int len = input.Length - 1;
        for (; Char.IsDigit(input[len]); len--);
        StringBuilder number = new StringBuilder();
        for (int i = len + 1; i < input.Length; i++)
        {
            number.Append(input[i]);
        }
        int cipherLen = int.Parse(number.ToString());
        string forDecoding = input.Substring(0, len + 1);
        input = Decode(forDecoding);
        string cipher = input.Substring(input.Length - cipherLen);
        string message = input.Substring(0, input.Length - cipherLen);
        Console.WriteLine(Encrypt(message, cipher));
    }
}

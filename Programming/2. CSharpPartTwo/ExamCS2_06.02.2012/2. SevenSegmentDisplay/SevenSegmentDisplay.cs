using System;
using System.Text;

class SevenSegmentDisplay
{
    static void GetPossibleDigits(byte digitPosition)
    {
        if (digitPosition == n)
        {
            output.Append(comb);
            output.Append('\n');
            return;
        }
        for (byte i = 0; i < digits.GetLength(0); i++)
        {
            if ((digits[i] & input[digitPosition]) == input[digitPosition])
            {
                comb[digitPosition] = (char)(i + '0');
                GetPossibleDigits((byte)(digitPosition + 1));
            }
        }
    }

    static byte n;
    static char[] comb;
    static StringBuilder output = new StringBuilder();
    static byte[] input;
    static byte[] digits = new byte[10]
                           {Convert.ToByte("1111110",2),
                            Convert.ToByte("0110000",2),
                            Convert.ToByte("1101101",2),
                            Convert.ToByte("1111001",2),
                            Convert.ToByte("0110011",2),
                            Convert.ToByte("1011011",2),
                            Convert.ToByte("1011111",2),
                            Convert.ToByte("1110000",2),
                            Convert.ToByte("1111111",2),
                            Convert.ToByte("1111011",2)};

    static void Main()
    {
        n = byte.Parse(Console.ReadLine());
        comb = new char[n];
        input = new byte[n];
        for (byte i = 0; i < n; i++)
        {
            input[i] = Convert.ToByte(Console.ReadLine(), 2);
        }
        GetPossibleDigits(0);
        Console.WriteLine(output.Length / (n + 1));
        Console.WriteLine(output);
    }
}

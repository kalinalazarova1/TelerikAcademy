using System;

class WeAllLoveBits
{
    static void Main()
    {
        ushort n = ushort.Parse(Console.ReadLine());
        uint[] num = new uint[n];
        for (ushort i = 0; i < n; i++)
        {
            num[i] = uint.Parse(Console.ReadLine());
            byte bitCount = (byte)(Math.Log(num[i], 2) + 1);
            byte[] temp = new byte[bitCount];
            uint numDoubleDot = 0;
            for (int j = 0; j < bitCount; j++)
            {

                temp[j] = (byte)((num[i] >> j) & 1);
            }
            Array.Reverse(temp);
            for (int j = 0; j < bitCount; j++)
            {
                numDoubleDot += (uint)(temp[j] * Math.Pow(2, j));
            }
            uint numWave = (num[i]) ^ (uint)(~((~ 0) << (int)bitCount));
            num[i] = (num[i] ^ numWave) & numDoubleDot;
        }
        for (ushort i = 0; i < n; i++)
        {
            Console.WriteLine(num[i]);
        }
    }
}

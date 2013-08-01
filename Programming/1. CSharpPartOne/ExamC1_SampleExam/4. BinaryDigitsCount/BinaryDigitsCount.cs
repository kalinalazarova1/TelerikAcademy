using System;



class BinaryDigitsCount
{
    static void Main()
    {
        byte bitValue = byte.Parse(Console.ReadLine());
        ushort intCount = ushort.Parse(Console.ReadLine());
        byte[] bitCount = new byte[intCount];
        ulong decimalNumber;
        for (ushort i = 0; i < intCount; i++)
        {
            decimalNumber = ulong.Parse(Console.ReadLine());
            for (; decimalNumber > 0; decimalNumber >>= 1)
            {
                if (decimalNumber % 2 == bitValue) bitCount[i]++;
                
            }
        }
        for (ushort i = 0; i < intCount; i++)
        {
            Console.WriteLine(bitCount[i]);
        }
    }
}

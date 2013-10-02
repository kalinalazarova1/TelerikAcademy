using System;
using System.Numerics;

class DurankulakNumbers
{
    static void Main()
    {
        string inputNumber = Console.ReadLine();
        BigInteger result = 0;
        int pow = 0;
        for (sbyte i = (sbyte)(inputNumber.Length - 1); i >= 0 ; i--, pow++)
        {
            if(i == 0 || Char.IsUpper(inputNumber[i - 1]))
            {
                result += (BigInteger)Math.Pow(168, pow) * (BigInteger)(inputNumber[i] - 'A');
            }
            else
            {
                result += (BigInteger)Math.Pow(168, pow) *(BigInteger)((inputNumber[i - 1] - 'a' + 1) * 26 + inputNumber[i] - 'A');
                i--;
            }
        }
        Console.WriteLine(result);
    }
}
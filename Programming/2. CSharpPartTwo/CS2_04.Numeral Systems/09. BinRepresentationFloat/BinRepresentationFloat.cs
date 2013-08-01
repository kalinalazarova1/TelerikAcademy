//9.* Write a program that shows internal binary representation of given 32-bit signed floating point
//number in IEEE 754 (the C# type float). Example: -27.25 -> sign = 1, exponent = 10000011, 
//mantissa = 101101000000000000000000.

using System;

class BinRepresentationFloat
{
    static void Main()
    {
        float inputNumber = -27.25f;
        if (inputNumber == 0)
        {
            Console.WriteLine("sign = 0, exponent = 00000000, mantissa = 00000000000000000000000");
            return;
        }
        int integer;
        float fraction;
        int point;
        int exponent = 0;
        int[] binaryExponent = new int[8];
        int[] binaryNumber = new int[64];
        int i = 0;
        Console.Write("sign = {0}", inputNumber < 0 ? 1 : 0);
        inputNumber = Math.Abs(inputNumber);
        integer = (int)inputNumber;
        fraction = inputNumber - integer;
        for (; integer != 0; i++, integer /= 2)
        {
            binaryNumber[i] = integer % 2;
        }
        for (int j = i; j < binaryNumber.GetLength(0) && fraction != 0; j++)
        {
            fraction *= 2;
            if (fraction >= 1)
            {
                binaryNumber[j] = 1;
                fraction -= 1;
            }
        }
        for (point = 0; point < binaryNumber.GetLength(0) && binaryNumber[point] != 1; point++) ;
        exponent = i - point - 1 + 127;
        for (int j = 0; exponent != 0; exponent /= 2, j++)
        {
            binaryExponent[j] = exponent % 2;
        }
        Console.Write(", exponent = ");
        for (int j = binaryExponent.GetLength(0) - 1; j >= 0; j--)
        {
            Console.Write("{0}", binaryExponent[j]);
        }
        Console.Write(", mantissa = ");
        for (int j = point + 1; j < point + 24; j++)
        {
            Console.Write(binaryNumber[j]);
        }
        Console.WriteLine();
    }
}

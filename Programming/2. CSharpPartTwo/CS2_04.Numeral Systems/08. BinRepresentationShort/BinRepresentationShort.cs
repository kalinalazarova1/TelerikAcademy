//8. Write a program that shows binary representation of 16-bit signed integer number (the C# type short).

using System;

class BinRepresentationShort
{
    /*static void Main()        //this is alternative solution of the problem;
    {
        short num = -345;
        Console.WriteLine(Convert.ToString(num,2).PadLeft(16, '0'));
    }*/

    static void Main()
    {
        short num = -3471;
        string result = string.Empty;
        ushort unsigned = (ushort)(num + 65536);
        for (int i = 0; unsigned > 0; i++)
        {
            result = result.Insert(0, (unsigned % 2).ToString());
            unsigned /= 2;
        }
        Console.WriteLine(result.PadLeft(16, '0'));
    }
}

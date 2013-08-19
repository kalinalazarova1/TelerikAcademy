using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class _9GagNumbers
{
    static sbyte GetDigitIndex(string dig)
    {
        for (sbyte i = 0; i < digit.Length; i++)
        {
            if (digit[i] == dig)
            {
                return i;
            }
        }
        return -1;
    }

    static string[] digit = {"-!","**","!!!","&&","&-","!-","*!!!","&*!","!!**!-"};

    static void Main()
    {

        string input = Console.ReadLine();
        StringBuilder singleDigit = new StringBuilder(6);
        ulong result = 0;
        List<byte> number = new List<byte>();
        ulong power = 1;
        for (int i = 0; i < input.Length; i++)
        {
            singleDigit.Append(input[i]);
            int index = GetDigitIndex(singleDigit.ToString());
            if (index == -1)
            {
                continue;
            }
            number.Add((byte)index);
            singleDigit.Clear();
        }
        for (sbyte i = (sbyte)(number.Count - 1); i >= 0; i--, power *= 9)
        {
            result += (ulong)(number[i] * power);
        }
        Console.WriteLine(result);
    }
}

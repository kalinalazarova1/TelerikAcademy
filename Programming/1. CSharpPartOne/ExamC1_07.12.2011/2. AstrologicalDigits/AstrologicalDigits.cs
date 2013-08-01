using System;
using System.Text;

class AstrologicalDigits
{
    static void Main()
    {
        char[] digit = new char[1];
        ushort result;
        StringBuilder inputNumber = new StringBuilder();
        inputNumber.Capacity = 302;
        inputNumber.Append(Console.ReadLine());
        inputNumber.Replace('.', '0');
        inputNumber.Replace('-', '0');
        do
        {
            result = 0;
            for (ushort i = 0; i < inputNumber.Length; i++)
            {
                inputNumber.CopyTo(i, digit, 0, 1);
                result += (ushort)(digit[0] - '0');
            }
            inputNumber.Clear();
            inputNumber.Append(result);
        }
        while (result > 9);
        Console.WriteLine(result);
    }
}

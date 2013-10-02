using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class KaspichanNumbers
{
    static void Main()
    {
        string[] kaspNumbers = new string[256];
        StringBuilder tempNum = new StringBuilder(2);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                if ((i * 26 + j) > 255)
                {
                    break;
                }
                if (i == 0)
                {
                    kaspNumbers[i * 26 + j] = tempNum.Append((char)('A' + j)).ToString();
                    tempNum.Clear();
                }
                else
                {
                    kaspNumbers[i * 26 + j] = tempNum.Append((char)('a' + i - 1)).ToString();
                    kaspNumbers[i * 26 + j] = tempNum.Append(kaspNumbers[j]).ToString();
                    tempNum.Clear();
                }
            }
        }
        BigInteger inputNumber = BigInteger.Parse(Console.ReadLine());
        byte remainder = 0;
        if (inputNumber == 0)
        {
            Console.WriteLine("A");
        }
        else
        {
            while (inputNumber > 0)
            {
                remainder = (byte)(inputNumber % 256);
                tempNum.Insert(0, kaspNumbers[remainder]);
                inputNumber = inputNumber / 256;
            }
            Console.WriteLine(tempNum);
        }
    }
}

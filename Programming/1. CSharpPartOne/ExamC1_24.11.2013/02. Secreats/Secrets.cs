using System;
using System.Collections.Generic;
using System.Text;

    class Secreats
    {
        static void Main()
        {
            ulong specialSum = 0;
            string num = Console.ReadLine();
            byte alphaSeqLength = 0;
            ushort step = 1;
            for (int i = num.Length - 1; i >= 0; i--, step++)
            {
                int temp = 0;
                if (Char.IsDigit(num[i]))
                {
                    temp = int.Parse(num[i].ToString());
                }
                else
                {
                    continue;
                }
                if ((step & 1) == 1)
                {
                    specialSum += (ulong)(step * step * temp);
                }
                else
                {
                    specialSum += (ulong)(step * temp * temp);
                }
            }
            alphaSeqLength = (byte)(specialSum % 10);
            StringBuilder alphaSeq = new StringBuilder();
            sbyte startLetter = (sbyte)(specialSum % 26);
            for (byte i = 0; i < alphaSeqLength; i++)
            {
                if (startLetter + 'A' + i > 'Z')
                {
                    startLetter = (sbyte)(-i);
                }
                alphaSeq.Append((char)(startLetter + 'A' + i));
            }
            if (num != "")
            {
                Console.WriteLine(specialSum);
            }
            if (alphaSeqLength != 0)
            {
                Console.WriteLine(alphaSeq.ToString());
            }
            else
            {
                Console.WriteLine("{0} has no secret alpha-sequence", num);
            }
        }
    }

using System;

class Problem_8_11
{
    static void Main()
    {
        int[] arabicNumber = new int[5];
        char[] romanNumber = new char[50];
        int result = 0;
        int tempDigit = 0;
        Console.WriteLine("Please input number in Roman digital system:");
        for (int i = 0; tempDigit != 10; i++)
        {
            tempDigit = Console.Read();
            romanNumber[i] = Convert.ToChar(tempDigit);
            switch (romanNumber[i])
            {
                case 'I': arabicNumber[i] = 1; break;
                case 'V': arabicNumber[i] = 5; break;
                case 'X': arabicNumber[i] = 10; break;
                case 'L': arabicNumber[i] = 50; break;
                case 'C': arabicNumber[i] = 100; break;
                case 'D': arabicNumber[i] = 500; break;
                case 'M': arabicNumber[i] = 1000; break;
                default: break;
            }
        }
        for (int i = 0; i < arabicNumber.GetLength(0) - 1; i++)
        {
            if (arabicNumber[i] < arabicNumber[i + 1])
            {
                result -= arabicNumber[i];
            }
            else
            {
                result += arabicNumber[i];
            }
        }
        result += arabicNumber[arabicNumber.GetLength(0) - 1];
        Console.Write("The arabic equivalent is: {0}", result);
        Console.WriteLine();
    }
}

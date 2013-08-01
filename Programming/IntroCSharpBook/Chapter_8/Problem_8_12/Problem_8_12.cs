using System;

class Problem_8_12
{
    static void Main(string[] args)
    {
        int[] romanValues = { 1000, 500, 100, 50, 10, 5, 1 };
        char[] romanDigits = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
        int arabicNumber;
        do
        {
            Console.WriteLine("Please input number between 0 and 3999 in Arabic digital system:");
            arabicNumber = Int32.Parse(Console.ReadLine());
        }
        while (arabicNumber < 1 || arabicNumber > 3999);
        Console.WriteLine("This number in Roman digital system is:");
        for (int i = 0; i < romanValues.GetLength(0); i += 2)
        {        
            switch (arabicNumber / romanValues[i])
            {
                case 1: Console.Write("{0}", romanDigits[i]); break;
                case 2: Console.Write("{0}{0}", romanDigits[i]); break;
                case 3: Console.Write("{0}{0}{0}", romanDigits[i]); break;
                case 4: Console.Write("{0}{1}", romanDigits[i], romanDigits[i - 1]); break;
                case 5: Console.Write("{0}", romanDigits[i - 1]); break;
                case 6: Console.Write("{0}{1}", romanDigits[i - 1], romanDigits[i]); break;
                case 7: Console.Write("{0}{1}{1}", romanDigits[i - 1], romanDigits[i]); break;
                case 8: Console.Write("{0}{1}{1}{1}", romanDigits[i - 1], romanDigits[i]); break;
                case 9: Console.Write("{0}{1}", romanDigits[i], romanDigits[i - 2]); break;
                default: break;
            }
            arabicNumber = arabicNumber % romanValues[i];   
        }
        Console.WriteLine();
    }
}

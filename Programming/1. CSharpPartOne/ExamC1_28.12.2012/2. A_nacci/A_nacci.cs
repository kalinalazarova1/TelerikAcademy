using System;

class A_nacci
{
    static void Main()
    {
        char anaciMinus1;      
        char anaciMinus2;
        int indexCurr;
        int lines;
        anaciMinus2 = char.Parse(Console.ReadLine());
        anaciMinus1 = char.Parse(Console.ReadLine());
        int indexMinus2 = anaciMinus2 - 'A' + 1;
        int indexMinus1 = anaciMinus1 - 'A' + 1;
        lines = int.Parse(Console.ReadLine());
        Console.WriteLine((char)(indexMinus2 + 'A' - 1));
        for (int i = 0; i < (lines - 1) * 2; i++)
        {
            indexCurr = indexMinus1 + indexMinus2;
            if (indexCurr > 26)
            {
                indexCurr -= 26;
            }
            indexMinus2 = indexMinus1;
            indexMinus1 = indexCurr;
            if (i % 2 == 0)
            {
                Console.Write((char)(indexMinus2 + (int)'A' - 1));
            }
            else
            {
                Console.WriteLine("{0}{1}", new string(' ', i / 2), (char)(indexMinus2 + (int)'A' - 1));
            }
        }
    }
}

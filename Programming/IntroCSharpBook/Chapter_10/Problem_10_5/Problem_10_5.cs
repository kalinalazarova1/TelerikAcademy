using System;

class Problem_10_5
{
    static string[] n = { "test", "rock", "fun" };   //all possible combinations with length from 0 to all
    static string[] loops;
    static bool[] used;
    static void PermutationWithoutRepetition(int curPosition, int curElement, int elemNumber)
    {
        if (curPosition == elemNumber)
        {
            PrintLoops();
            return;
        }
        for (int i = curElement; i < n.GetLength(0); i++)
        {
            if (!used[i])
            {
                used[i] = true;
                loops[curPosition] = n[i];
                PermutationWithoutRepetition(curPosition + 1, i, elemNumber);
                used[i] = false;
            }
        }
    }
    static void PrintLoops()
    {
        for (int i = 0; i < loops.GetLength(0); i++)
        {
            if (loops.GetLength(0) == 1)
                Console.Write("({0}) ", loops[i]);
            else if (i == loops.GetLength(0) - 1)
                Console.Write("{0}) ", loops[i]);
            else if (i == 0)
                Console.Write("({0} ", loops[i]);
            else
                Console.Write("{0} ", loops[i]);
        }
    }
    static void Main()
    {
        used = new bool[n.GetLength(0)];
        for (int i = - 1; i < n.GetLength(0); i++)
        {
            if (i == - 1)
            {
                Console.Write("() ");
                i++;
            }
            loops = new string[i + 1];
            PermutationWithoutRepetition(0, 0, i + 1);
        }
        Console.WriteLine();
    }
}

using System;

class Problem_10_7
{                       //permutation with repetition to all numbers from 1 to n
    static int n;       //count of the positions
    static int[] loops;
    static bool[] used;
    static void PermutationWithoutRepetition(int curLoop, int curPosition)
    {
        if (curLoop == n)
        {
            PrintLoops();
            return;
        }
        for (int i = curPosition; i < n; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                loops[curLoop] = i + 1;
                PermutationWithoutRepetition(curLoop + 1, 0);
                used[i] = false;
            }
        }
    }

    static void PrintLoops()
    {
        for (int i = 0; i < loops.GetLength(0); i++)
        {
            if (i == loops.GetLength(0) - 1)
                Console.Write("{0}) ", loops[i]);
            else if (i == 0)
                Console.Write("({0}, ", loops[i]);
            else
                Console.Write("{0}, ", loops[i]);
        }
    }
    static void Main()
    {
        Console.WriteLine("Please input the count of the elements:");
        n = Int32.Parse(Console.ReadLine());
        loops = new int[n];
        used = new bool[n];
        PermutationWithoutRepetition(0, 0);
        Console.WriteLine();
    }
    
}

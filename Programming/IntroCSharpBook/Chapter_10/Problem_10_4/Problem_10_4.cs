using System;

class Problem_10_4
{
    static string[] n = { "test", "rock", "fun"};   //permutation without repetition
    static int k;       //count of the positions
    static string[] loops;
    static bool[] used; 
    static void PermutationWithoutRepetition(int curLoop, int curPosition)
    {
        if (curLoop == k)
        {
            PrintLoops();
            return;
        }
        for (int i = curPosition; i < n.GetLength(0); i++)
        {
            if (!used[i])
            {
                used[i] = true;
                loops[curLoop] = n[i];
                PermutationWithoutRepetition(curLoop + 1, i);
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
        k = Int32.Parse(Console.ReadLine());
        loops = new string[k];
        used = new bool[n.GetLength(0)];
        PermutationWithoutRepetition(0,0);
        Console.WriteLine();
    }
}

using System;

class Problem_10_8
{
    static int[] arr = { 2,4,5,1,3,-1 };   //all possible combinations with a sum n
    static int[] combi;
    static int n = 6;
    static bool[] used;
    static void PermutationWithoutRepetition(int curPosition, int curElement, int PositionCount)
    {
        if (curPosition == PositionCount)
        {
            if (SumCombi() == n)
            {
                PrintCombi();
            }
            return;
        }
        for (int i = curElement; i < arr.GetLength(0); i++)
        {
            if (!used[i])
            {
                used[i] = true;
                combi[curPosition] = arr[i];
                PermutationWithoutRepetition(curPosition + 1, i, PositionCount);
                used[i] = false;
            }
        }
    }
    static int SumCombi()
    {
        int sum = 0;
        for (int i = 0; i < combi.GetLength(0); i++)
            sum += combi[i];
        return sum;

    }
    static void PrintCombi()
    {
        for (int i = 0; i < combi.GetLength(0); i++)
        {
            if (combi.GetLength(0) == 1)
                Console.Write("({0}) ", combi[i]);
            else if (i == combi.GetLength(0) - 1)
                Console.Write("{0}) ", combi[i]);
            else if (i == 0)
                Console.Write("({0} ", combi[i]);
            else
                Console.Write("{0} ", combi[i]);
        }
    }
    static void Main()
    {
        used = new bool[arr.GetLength(0)];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            combi = new int[i + 1];
            PermutationWithoutRepetition(0, 0, i + 1);
        }
        Console.WriteLine();
    }
}

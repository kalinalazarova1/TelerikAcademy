using System;

class Problem_10_2       //combinations with repetition
{
    static int n;       //maximal value
    static int k;       //count of the positions
    static int[] loops;
    static void CombinationsWithRepetition(int curLoop, int curNumber)
    {
        if (curLoop == k)
        {
            PrintLoops();
            return;
        }
        for (int i = curNumber; i < n; i++)
        {
            loops[curLoop] = i + 1;
            CombinationsWithRepetition(curLoop + 1, i);
        }
    }
    static void PrintLoops()
    {
        for (int i = 0; i < loops.GetLength(0); i++)
        {
            if(i == loops.GetLength(0) - 1)
            Console.Write("{0}) ", loops[i]);
            else if(i == 0)
            Console.Write("({0}, ", loops[i]);
            else
            Console.Write("{0}, ", loops[i]);
        }
    }
    static void Main()
    {
        Console.WriteLine("Please input the count of the elements:");
        k = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input the maximum value of the element:");
        n = Int32.Parse(Console.ReadLine());
        loops = new int[k];
        CombinationsWithRepetition(0, 0);
        Console.WriteLine();
    }
}

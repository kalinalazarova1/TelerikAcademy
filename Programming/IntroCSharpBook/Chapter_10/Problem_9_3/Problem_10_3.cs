using System;

class Problem_10_3       //variations with repetition
{
    static int n;       //maximal value
    static int k;       //count of the positions
    static int[] loops;
    static void VariationsWithRepetition(int curLoop)
    {
        if (curLoop == k)
        {
            PrintLoops();
            return;
        }
        for (int i = 1; i <= n ; i++)
        {
            loops[curLoop] = i;
            VariationsWithRepetition(curLoop + 1);
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
        Console.WriteLine("Please input the maximum value of the element:");
        n = Int32.Parse(Console.ReadLine());
        loops = new int[k];
        VariationsWithRepetition(0);
        Console.WriteLine();
    }
}

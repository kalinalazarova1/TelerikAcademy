using System;

class Problem_10_1
{
    static int n;
    static int[] loops;
    static void NestedLoops(int curLoop)
    {
        if(curLoop == n)
        {
            PrintLoops();
            return;
        }
        for (int i = 1; i <= n; i++)
        {
            loops[curLoop] = i;
            NestedLoops(curLoop + 1);
        }
    }
    static void PrintLoops()
    {
        for (int i = 0; i < loops.GetLength(0); i++)
        {
            Console.Write("{0} ", loops[i]);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.WriteLine("Please input the number of the nested loops:");
        n = Int32.Parse(Console.ReadLine());
        loops = new int[n];
        NestedLoops(0);
    }
}

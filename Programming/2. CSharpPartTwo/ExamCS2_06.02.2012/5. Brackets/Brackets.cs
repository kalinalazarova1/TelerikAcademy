using System;
using System.Numerics;

class Brackets
{
    static void Main()
    {
        string input = Console.ReadLine();
        BigInteger[,] combCount = new BigInteger[input.Length / 2 + 1, input.Length]; //combinations count with number open brackets
        combCount[1, 0] = 1;
        for (int c = 1; c < combCount.GetLength(1); c++)
        {
            for (int r = 0; r < combCount.GetLength(0); r++)
            {
                if (combCount[r, c - 1] > 0)
                {
                    if (input[c] == '(' && r + 1 < combCount.GetLength(0))
                    {
                        combCount[r + 1, c] += combCount[r, c - 1];
                    }
                    else if (input[c] == ')' && r - 1 >= 0)
                    {
                        combCount[r - 1, c] += combCount[r, c - 1];
                    }
                    else if(input[c] == '?' && r + 1 < combCount.GetLength(0)) 
                    {
                        combCount[r + 1, c] += combCount[r, c - 1]; ;
                    }
                    if (input[c] == '?' && r - 1 >= 0)
                    {
                        combCount[r - 1, c] += combCount[r, c - 1]; ;
                    }
                }
            }
        }
        Console.WriteLine(combCount[0, combCount.GetLength(1) - 1]);
    }
}

//2. What is the expected running time of the following C# code? Explain why. Assume the input matrix has size of n * m.
//
//Solution:
// The first for loop is executed n times which is the number of the rows in the matrix. Then the if is executed from 0 times
// in the best case to n times in the worst case and n / 2 times on average. The second for loop is executed m times which is 
// the number of the columns in the matrix. The most inner if is executed from 0 times in the best case to m times in the worst
// case and m / 2 on average. This means the method CalcCount makes 0 steps in the best case and m * n steps in the worst case 
// and n / 2 * m / 2 elementary steps on average. As 1/2 are relatively small and not dependant on the size of the martix we 
// assume n / 2 * m / 2 to be relatively equal to n * m. Therefore the metod CalcCount runs on average in quadratic time O(n * m).

using System;

class Task2
{
    static long CalcCount(int[,] matrix)
    {
        long count = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
            if (matrix[row, 0] % 2 == 0)
                for (int col = 0; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] > 0)
                        count++;
        return count;
    }

    static void Main()
    {
        int n = 200;            //could be tested with different values of n
        int m = 100;            //could be tested with different values of m
        var arr = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr[i, j] = 2;
            }
        }
        Console.WriteLine("For array of size [{0}, {1}] executes {2} operations", n, m, CalcCount(arr));
    }
}

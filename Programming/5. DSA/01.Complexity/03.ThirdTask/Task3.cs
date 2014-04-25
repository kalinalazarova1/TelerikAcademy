//3.* What is the expected running time of the following C# code? Explain why. Assume the input matrix has size of n * m.
//
//Solution:
// The for loop is executed m times (the number of the columns in the matrix). Then the if is entered n times (each time the
// row is increased with 1 and the method is called with the new row) until all the rows are summed. Therefore the method will
// execute n * m elementary steps and will run in quadratic time O(n * m).

using System;
class Task3
{
    static long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;
        for (int col = 0; col < matrix.GetLength(1); col++) 
            sum += matrix[row, col];
        if (row + 1 < matrix.GetLength(0)) 
            sum += CalcSum(matrix, row + 1);
        return sum;
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
                arr[i, j] = 1;
            }
        }
        Console.WriteLine("For array of size [{0}, {1}] executes {2} operations", n, m, CalcSum(arr, 0));
    }
}

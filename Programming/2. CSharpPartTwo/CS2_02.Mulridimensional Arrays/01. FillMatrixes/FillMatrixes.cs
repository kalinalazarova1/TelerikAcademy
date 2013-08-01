//1. Write a progarm that fills and prints a matrix of size (n,n)
// as shown below: (examples for n = 4)
// 
//  a)   1  5   9  13            b)  1  8   9  16
//       2  6  10  14                2  7  10  15
//       3  7  11  15                3  6  11  14
//       4  8  12  16                4  5  12  13
//  
//  
//  c)   7  11  14  16           d)* 1  12  11  10
//       4   8  12  15               2  13  16   9
//       2   5   9  13               3  14  15   8 
//       1   3   6  10               4   5   6   7  
// 

using System;

class FillMatrixes
{
    static void PrintMatrix(int[,] arr)
    {
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write("{0,3}", arr[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static int[,] FillMatrixVertically(int n)
    {
        int value = 1;
        int[,] arr = new int[n, n];
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                arr[row, col] = value;
                value++;
            }
        }
        return arr;
    }

    static int[,] FillMatrixSnake(int n)
    {
        int value = 1;
        int[,] arr = new int[n, n];
        for (int col = 0; col < n; col++)
        {
            if ((col & 1) == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    arr[row, col] = value;
                    value++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    arr[row, col] = value;
                    value++;
                }
            }
        }
        return arr;
    }

    static int[,] FillMatrixDiagonally(int n)
    {
        int value = 1;
        int[,] arr = new int[n, n];
        for (int count = 0; count < n; count++)
        {
            for (int row = n - 1 - count, col = 0; row < n; row++, col++)
            {
                arr[row, col] = value;
                value++;
            }
        }
        for (int count = 0; count < n - 1; count++)
            for (int row = 0, col = 1 + count; col < n; row++, col++)
            {
                arr[row, col] = value;
                value++;
            }
       return arr;
    }

    static int[,] FillMatrixSpiral(int n)
    {
        int value = 1;
        int[,] arr = new int[n, n];
        for (int g = 0; g < (n / 2); g++)
        {
            for (int i = 0 + g; i <= n - 2 - g; i++)
            {
                arr[i, 0 + g] = value;
                value++;
            }
            for (int i = 0 + g; i <= n - 2 - g; i++)
            {
                arr[n - 1 - g, i] = value;
                value++;
            }
            for (int i = n - 1 - g; i > 0 + g; i--)
            {
                arr[i, n - 1 - g] = value;
                value++;
            }
            for (int i = n - 1 - g; i > 0 + g; i--)
            {
                arr[0 + g, i] = value;
                value++;
            }
        }
        if (n % 2 == 1)
        {
            arr[n / 2, n / 2] = n * n;
        }
        return arr;
    }

    static void Main()
    {
        Console.WriteLine("Please input size for the matrix:");
        int size = int.Parse(Console.ReadLine());
        PrintMatrix(FillMatrixVertically(size));
        PrintMatrix(FillMatrixSnake(size));
        PrintMatrix(FillMatrixDiagonally(size));
        PrintMatrix(FillMatrixSpiral(size));
    }
}

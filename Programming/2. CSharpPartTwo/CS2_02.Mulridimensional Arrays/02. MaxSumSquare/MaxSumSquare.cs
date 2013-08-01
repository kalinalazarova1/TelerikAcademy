//2. Write a program that reads a rectangular matrix of size N X M and finds in it the square 3 x 3
//that has maximal sum of its elements.

using System;

class MaxSumSquare
{
    static int GetSquare3X3Sum(int[,] matrix, int startRow, int startColumn)
    {
        int sum = 0;
        for (int r = startRow; r < startRow + 3; r++)
        {
            for (int c = startColumn; c < startColumn + 3; c++)
            {
                sum += matrix[r, c];
            }
        }
        return sum;
    }

    static void PrintSquare3X3(int[,] matrix, int row, int col)
    {
        for (int r = row; r < row + 3; r++)
        {
            for (int c = col; c < col + 3; c++)
            {
                Console.Write("{0,3}", matrix[r, c]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int maxSum = int.MinValue;
        int maxRow = 0;
        int maxColumn = 0;
        Console.WriteLine("Please input the number of the rows of the matrix:");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Please input the number of the colums of the matrix:");
        int colums = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, colums];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < colums; c++)
            {
                Console.WriteLine("Please input element ({0},{1}):", r, c);
                matrix[r, c] = int.Parse(Console.ReadLine());
            }   
        }
        for (int r = 0; r < rows - 2; r++)
        {
            for (int c = 0; c < colums - 2; c++)
            {
                int currentSum = GetSquare3X3Sum(matrix, r, c);
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxRow = r;
                    maxColumn = c;
                }
            }
        }
        Console.WriteLine("Maximal sum is: {0}", maxSum);
        Console.WriteLine("The square is:");
        PrintSquare3X3(matrix, maxRow, maxColumn);
    }
}

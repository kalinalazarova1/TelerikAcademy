//5. Write a program that reads a text file containing a square matrix of numbers and finds in the
//matrix an area of size 2x2 with a maximal sum of its elements. The first line in the input file
//contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
//The output should be a single number in a separate text file. Example:
//  4
//  2 	3 	3 	4
//  0 	2 	3 	4       
//  3 	7 	1 	2      3   7 -> 17
//  4 	3 	3 	2      4   3
//

using System;
using System.IO;
using System.Collections.Generic;

class MaxSumMatrix2X2FromFile
{
    static int GetSquare3X3Sum(int[,] matrix, int startRow, int startColumn)
    {
        int sum = 0;
        for (int r = startRow; r < startRow + 2; r++)
        {
            for (int c = startColumn; c < startColumn + 2; c++)
            {
                sum += matrix[r, c];
            }
        }
        return sum;
    }
    static void Main()
    {
        int maxSum = int.MinValue;
        int[,] matrix;
        using (StreamReader reader = new StreamReader("input.txt"))
        {
            int n = int.Parse(reader.ReadLine());
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] splittedLine = (reader.ReadLine().Split(' '));
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(splittedLine[j]);
                }
            }
        }
        for (int r = 0; r < matrix.GetLength(0) - 1; r++)
        {
            for (int c = 0; c < matrix.GetLength(1) - 1; c++)
            {
                int currentSum = GetSquare3X3Sum(matrix, r, c);
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            writer.WriteLine(maxSum);
        }
    }
}
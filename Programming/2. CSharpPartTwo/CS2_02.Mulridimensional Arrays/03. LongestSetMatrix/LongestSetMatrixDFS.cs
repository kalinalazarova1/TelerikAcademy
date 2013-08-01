//3. We are given a matrix of strings of size N x M. Sequences in the matrix we define as 
//sets of several neighbor elements located on the same line, column or diagonal. 
//Write a program that finds the longest sequence of equal strings in the matrix.

using System;

class LongestSetMatrix
{
    static void Move(string[,] matrix, bool[,] isVisited, int currLength, string curStr, int startRow, int startCol)
    {
        if (startRow == matrix.GetLength(0) || startRow < 0 || startCol == matrix.GetLength(1) || startCol < 0)
        {
            return;
        }
        if (isVisited[startRow, startCol])
        {
            return;
        }
        if (matrix[startRow, startCol] != curStr)
        {
            return;
        }
        currLength++;
        isVisited[startRow, startCol] = true;
        Move(matrix, isVisited, currLength, curStr, startRow + 1, startCol);
        Move(matrix, isVisited, currLength, curStr, startRow, startCol + 1);
        Move(matrix, isVisited, currLength, curStr, startRow + 1, startCol + 1);
        Move(matrix, isVisited, currLength, curStr, startRow + 1, startCol - 1);
        if (currLength > maxLength)
        {
            maxLength = currLength;
        }
        currLength = 0;
    }

    static int maxLength = 1;
    static int maxRow = 0;
    static int maxCol = 0;

    static void Main()
    {
        string[,] matrix = { { "ha", "fifi", "ho", "hi" }, { "fo", "ha", "hi", "xx" }, { "xxx", "ho", "ha", "xx" } };
        //string[,] matrix = { { "s", "qq", "s" }, { "pp", "pp", "s" }, { "pp", "qq", "s" } };

        bool[,] isVisited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        int currLength = 0;
        for (int r = 0; r < matrix.GetLength(0); r++)
			{
                for (int c = 0; c < matrix.GetLength(1); c++)
			    {
			        Move(matrix, isVisited, currLength, matrix[r,c], r, c);
			    }
			}
        Console.WriteLine("The string \"{0}\" forms a maximal set of {1} elements.", matrix[maxRow, maxCol],maxLength);
    }
}

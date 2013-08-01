//7.* Write a program that finds the largest area of equal neighbor elements in a rectangular matrix
//and prints its size.
/*
 1 	3 	2 	2 	2 	4
 3 	3 	3 	2 	4 	4
 4 	3 	1 	2 	3 	3   -> 13
 4 	3 	1 	3 	3 	1
 4 	3 	3 	3 	1 	1
 */

using System;

class LargestAreaInMatrixDFS
{
    static void Move(int[,] matrix, bool[,] isVisited, int curElem, int startRow, int startCol)
    {
        if (startRow == matrix.GetLength(0) || startRow < 0 || startCol == matrix.GetLength(1) || startCol < 0)
        {
            return;
        }
        if (isVisited[startRow, startCol])
        {
            return;
        }
        if (matrix[startRow, startCol] != curElem)
        {
            return;
        }
        currLength++;
        isVisited[startRow, startCol] = true;
        Move(matrix, isVisited, curElem, startRow + 1, startCol);
        Move(matrix, isVisited, curElem, startRow - 1, startCol);
        Move(matrix, isVisited, curElem, startRow, startCol + 1);
        Move(matrix, isVisited, curElem, startRow, startCol - 1);
    }

    static int currLength = 0;

    static void Main()
    {
        int maxLength = 1;
        int[,] matrix = {{1,3,2,2,2,4},{3,3,3,2,4,4},{4,3,1,2,3,3},{4,3,1,3,3,1},{4,3,3,3,1,1}};
        bool[,] isVisited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                currLength = 0;
                Move(matrix, isVisited, matrix[r, c], r, c);
                if (currLength > maxLength)
                {
                    maxLength = currLength;
                }
            }
        }
        Console.WriteLine("The maximal area consists of {0} elements.", maxLength);
    }
}

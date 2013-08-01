//Write a program that reads from the console a positive integer number (N < 20) and
//outputs a matrix like the following:
//      
//  N = 4   1 2 3       N = 4   1 2 3 4
//          2 3 4               2 3 4 5
//          3 4 5               3 4 5 6
//                              4 5 6 7
//

using System;

class DiagonalMatrix
{
    static void Main()
    {
        byte matrixSize;
        bool isValid;
        do
        {
            Console.WriteLine("Please input matrix size < 20:");
            isValid = byte.TryParse(Console.ReadLine(), out matrixSize);
        }
        while (!isValid || matrixSize >= 20);
        for (int i = 1; i <= matrixSize; i++)
        {
            for (int j = i; j < matrixSize + i; j++)
            {
                Console.Write("{0,2} ", j);   
            }
            Console.WriteLine();
        }
    }
}

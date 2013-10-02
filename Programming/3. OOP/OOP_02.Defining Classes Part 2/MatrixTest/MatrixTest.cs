//8.Define a class Matrix to hold a matrix of numbers (e.g. integers, floats, decimals).
//9.Implement an indexer this[row, col] to access the inner matrix cells.
//10.Implement the operators + and - (addition and subtraction of matrices of the same size) 
//and * for matrix multiplication. Throw an exception when the operation cannot be performed. 
//Implement the true operator (check for non-zero elements).


using System;
using Matrix;

namespace MatrixTest
{
    class MatrixTest
    {
        static void Main()
        {
            int[,] arr = {{2, 45, 11}, {23, -1, 24}, {0, 4, 6}};
            Matrix<int> test1 = new Matrix<int>(arr); //test the two constructors of the class Matrix
            Matrix<int> test2 = new Matrix<int>(3, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    test2[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("First matrix:");
            Console.WriteLine(test1);               //test to ToString() method of the class Matrix
            Console.WriteLine("Second matrix:");
            Console.WriteLine(test2);
            Console.WriteLine("The second matrix is empty:");
            if (test2)                               //test operator true
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            } 
            Console.WriteLine("Add result:");
            Console.WriteLine(test1 + test2);       //Test operator + in the class Matrix           
            Console.WriteLine("Substract result:");
            Console.WriteLine(test1 - test2);       //Test operator - in the class Matrix
            Console.WriteLine("Multiplication result:");
            Console.WriteLine(test1 * test2);       //Test operator * in the class Matrix               

        }
    }
}

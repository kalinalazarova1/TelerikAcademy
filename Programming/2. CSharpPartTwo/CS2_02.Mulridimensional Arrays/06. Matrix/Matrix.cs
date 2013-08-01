//6*. Write a class Matrix to hold an array of integers. Overload the opertions for adding, substracting
//and multiplying the matrices, indexer to accessing the matrix content and ToString(). 

using System;
using System.Text;

class Matrix
{
    private int rows;
    private int cols;
    private int[,] matrix;

    public Matrix(int r, int c)
    {
        this.rows = r;
        this.cols = c;
        matrix = new int[r, c];
    }

    public Matrix(int[,] arr)
    {
        this.rows = arr.GetLength(0);
        this.cols = arr.GetLength(1);
        matrix = new int[this.rows, this.cols];
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                matrix[i, j] = arr[i, j];
            }   
        }
    }

    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        Matrix result = new Matrix(m1.rows, m1.cols);
        if (m1.rows != m2.rows || m1.cols != m2.cols)
        {
            throw new FormatException("The matrices could not be added, because they are with different dimensions.");
        }
        for (int i = 0; i < m1.rows; i++)
        {
            for (int j = 0; j < m1.cols; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }
        return result;
    }

    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        Matrix result = new Matrix(m1.rows, m1.cols);
        if (m1.rows != m2.rows || m1.cols != m2.cols)
        {
            throw new FormatException("The matrices could not be substracted, because they are with different dimensions.");
        }
        for (int i = 0; i < m1.rows; i++)
        {
            for (int j = 0; j < m1.cols; j++)
            {
                result[i, j] = m1[i, j] - m2[i, j];
            }
        }
        return result;
    }

    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        Matrix result = new Matrix(m1.rows, m2.cols);
        if (m1.cols != m2.rows)
        {
            throw new FormatException("The matrices could not be multiplied, because they are with irrelevant dimensions.");
        }
        for (int i = 0; i < m1.rows; i++)
        {
            for (int j = 0; j < m2.cols; j++)
            {
                for (int k = 0; k < m1.cols; k++)
                {
                    result[i, j] += m1[i, k] * m2[k, j]; 
                }
            }
        }
        return result;
    }

    public int this[int i, int j]
    {
        get
        {
            return matrix[i, j];
        }
        set
        {
            matrix[i, j] = value;
        }
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder(rows * (cols + 1));
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                str.Append(String.Format("{0, 4}",this[i, j]));
            }
            str.Append("\n");
        }
        return str.ToString();
    }

    static void Main()
    {
        int[,] arr1 = { { 1, 7, 8 }, { 2, 3, 4 }, { 7, 1, 9 } };
        Matrix m1 = new Matrix(arr1);
        int[,] arr2 = { { 1, 3, 7 }, { 2, 2, 3 }, { 6, 3, 1 } };
        //int[,] arr2 = { { 1, 7, 7 }, { 2, 3, 1 } };
        Matrix m2 = new Matrix(arr2);
        Console.WriteLine("First matrix:");
        Console.WriteLine(m1.ToString());
        Console.WriteLine("Second matrix:");
        Console.WriteLine(m2.ToString());
        try
        {
            Console.WriteLine("Result after adding:");
            Console.WriteLine((m1 + m2).ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            Console.WriteLine("Result after substracting:");
            Console.WriteLine((m1 - m2).ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            Console.WriteLine("Result after multipling:");
            Console.WriteLine((m1 * m2).ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

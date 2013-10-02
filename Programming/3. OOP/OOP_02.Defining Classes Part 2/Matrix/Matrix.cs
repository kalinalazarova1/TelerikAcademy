using System;
using System.Text;

namespace Matrix
{
    public class Matrix<T> where T : struct //this constraint is important because the matrix elements must be value types
    {                                       //it means that tha operators +, - and * make sense for them
        private int rows;
        public int Rows 
        {
            get
            {
                return this.rows;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new IndexOutOfRangeException("Matrix rows must be greater than zero!");
                }
                else
                {
                    this.rows = value;
                }
            }
        }

        private int cols;
        public int Cols
        {
            get
            {
                return this.cols;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new IndexOutOfRangeException("Matrix columns must be greater than zero!");
                }
                else
                {
                    this.cols = value;
                }
            }
        }
        private T[,] matrix;

        public Matrix(int r, int c)
        {
            this.Rows = r;
            this.Cols = c;
            this.matrix = new T[r, c];
        }

        public Matrix(T[,] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("The source array could not be empty!");
            }
            else
            {
                this.Rows = arr.GetLength(0);
                this.Cols = arr.GetLength(1);
                this.matrix = new T[arr.GetLength(0), arr.GetLength(1)];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        this.matrix[i, j] = arr[i, j];
                    }
                }
            }
        }

        public T this[int r, int c]
        {
            get
            {
                if (r < 0 || r >= this.Rows || c < 0 || c >= this.Cols)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return this.matrix[r, c];
                }
            }
            set
            {
                if (r < 0 || r >= this.Rows || c < 0 || c >= this.Cols)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    this.matrix[r, c] = value;
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException("The matrices that are to be added must be of the same size!");
            }
            else
            {
                for (int i = 0; i < first.Rows; i++)
                {
                    for (int j = 0; j < first.Cols; j++)
                    {
                        result[i, j] = (dynamic)first[i, j] + second[i, j];
                    }
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException("The matrices that are to be substracted must be of the same size!");
            }
            else
            {
                for (int i = 0; i < first.Rows; i++)
                {
                    for (int j = 0; j < first.Cols; j++)
                    {
                        result[i, j] = (dynamic)first[i, j] - second[i, j];
                    }
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            Matrix<T> result = new Matrix<T>(first.rows, second.cols);
            if (first.cols != second.rows)
            {
                throw new ArgumentException("The matrices could not be multiplied, because they are with irrelevant dimensions.");
            }
            for (int i = 0; i < first.rows; i++)
            {
                for (int j = 0; j < second.cols; j++)
                {
                    for (int k = 0; k < first.cols; k++)
                    {
                        result[i, j] += (dynamic)first[i, k] * second[k, j];
                    }
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> m)
        {
            for (int i = 0; i < m.Rows; i++)
			{
			    for (int j = 0; j < m.Cols; j++)
			    {
			        if(!m[i, j].Equals(default(T)))
                    {
                        return false;
                    }
			    }
			}
            return true;
        }

        public static bool operator false(Matrix<T> m)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    if (!m[i, j].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder(this.Rows * (this.Cols + 1));
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    str.Append(String.Format("{0, 4}", this[i, j]));
                }
                str.Append("\n");
            }
            return str.ToString();
        }


    }
}

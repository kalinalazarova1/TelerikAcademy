using System;

class Sudoku
{
    static void PrintSudoku(byte[,] sudoku)
    {
        for (int r = 0; r < sudoku.GetLength(0); r++)
        {
            for (int c = 0; c < sudoku.GetLength(1); c++)
            {
                Console.Write(sudoku[r, c]);
            }
            Console.WriteLine();
        }
    }

    static bool IsPossibleNumber(byte[,] sudoku, byte[,] initial, int num, int r, int c)
    {
        int or = r % 3;
        int oc = c % 3;
        if (initial[r, c] != 0 && initial[r, c] == num)
        {
            return true;
        }
        else if(initial[r, c] != 0 && initial[r, c] != num)
        {
            return false;
        }
        for (int i = 0; i < 9; i++)
        {
            if ((i != c && sudoku[r, i] == num) || (i != r && sudoku[i, c] == num))
            {
                return false;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (num == sudoku[r - or + i, c - oc + j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    static void GetSudoku(byte[,] sudoku, byte[,] initial, int start)
    {
        int r = start / 9;
        int c = start % 9;
        if (start > 80)
        {
            PrintSudoku(sudoku);
            Environment.Exit(0);
        }
        for (byte i = 1; i <= 9; i++)
        {
            if (IsPossibleNumber(sudoku, initial, i, r, c))
            {
                sudoku[r, c] = i;
                GetSudoku(sudoku, initial, start + 1);
                sudoku[r, c] = initial[r, c];
            }
        }
    }
    
    static void Main()
    {
        byte[,] initialSudoku = new byte[9, 9];
        byte[,] sudoku = new byte[9, 9];
        for (int r = 0; r < 9; r++)
        {
            string line = Console.ReadLine();
            for (int c = 0; c < 9; c++)
            {
                if (line[c] != '-')
                {
                    sudoku[r, c] = byte.Parse(line[c].ToString());
                }
                else
                {
                    sudoku[r, c] = 0; 
                }
                initialSudoku[r, c] = sudoku[r, c];
            }
        }
        GetSudoku(sudoku, initialSudoku, 0);
    }
}

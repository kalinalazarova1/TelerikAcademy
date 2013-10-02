using System;

class TicTactoeV2
{
    static bool IsWonFirst(int[,] field)
    {
        int sumDiagFirst = field[0, 0] + field[1, 1] + field[2, 2];
        int sumDiagSecond = field[0, 2] + field[1, 1] + field[2, 0];
        for (int i = 0; i < 3; i++)
        {
            int sumVert = 0;
            int sumHor = 0;
            for (int j = 0; j < 3; j++)
            {
                sumVert += field[j, i];
                sumHor += field[i, j];
            }
            if (sumVert == 3 || sumHor == 3 || sumDiagFirst == 3 || sumDiagSecond == 3)
            {
                return true;
            }
        }
        return false;
    }

    static bool IsWonSecond(int[,] field)
    {
        int sumDiagFirst = field[0, 0] + field[1, 1] + field[2, 2];
        int sumDiagSecond = field[0, 2] + field[1, 1] + field[2, 0];
        for (int i = 0; i < 3; i++)
        {
            int sumVert = 0;
            int sumHor = 0;
            for (int j = 0; j < 3; j++)
            {
                sumVert += field[j, i];
                sumHor += field[i, j];
            }
            if (sumVert == -3 || sumHor == -3 || sumDiagFirst == -3 || sumDiagSecond == -3)
            {
                return true;
            }
        }
        return false;
    }

    static void GetWinner(int[,] field, bool[] isFree)
    {
        if (IsWonFirst(field))
        {
            countFirstWins++;
        }
        else if (IsWonSecond(field))
        {
            countSecondWins++;
        }
        else if (IsFull(field) && !IsWonSecond(field) && !IsWonFirst(field))
        {
            evenGames++;
        }
    }

    static bool IsFull(int[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    static int[,] Transform(int[] comb)
    {
        int[,] field = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                field[i, j] = comb[i * 3 + j];
            }
        }
        return field;
    }

    static void GetComb(int[] comb, bool[] isFree)
    {
        int[,] curr = Transform(comb);
        if (IsWonFirst(curr) || IsWonSecond(curr) || IsFull(curr))
        {   
            GetWinner(curr, isFree);
            return;
        }
        for(int i = 0; i < comb.Length; i++)
        {
            if (isFree[i])
            {
                if (firstTurn)
                {
                    comb[i] = 1;
                    isFree[i] = false;
                    firstTurn = false;
                    GetComb(comb, isFree);
                    comb[i] = 0;
                    isFree[i] = true;
                    firstTurn = true;
                }
                else
                {
                    comb[i] = -1;
                    isFree[i] = false;
                    firstTurn = true;
                    GetComb(comb, isFree);
                    comb[i] = 0;
                    isFree[i] = true;
                    firstTurn = false;
                }
            }
        }
    }
    
    static int SumComb(int[] comb)
    {
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += comb[i];
        }
        return sum;
    }

    static int countFirstWins = 0;

    static int countSecondWins = 0;

    static int evenGames = 0;

    static bool firstTurn;

    static void Main()
    {
        int[,] field = new int[3, 3];
        int[] comb = new int[9];
        bool[] isFree = new bool[9];
        for (int i = 0; i < 3; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < 3; j++)
            {
                switch (line[j])
                {
                    case 'X': comb[i * 3 + j] = 1; break;
                    case 'O': comb[i * 3 + j] = -1; break;
                    case '-':
                        comb[i * 3 + j] = 0;
                        isFree[i * 3 + j] = true;
                        break;
                    default: break;
                }
            }
        }
        if (SumComb(comb) == 0)
        {
            firstTurn = true;
        }
        else
        {
            firstTurn = false;
        }
        GetComb(comb, isFree);
        Console.WriteLine("{0}\n{1}\n{2}\n", countFirstWins, evenGames, countSecondWins);
    }
}

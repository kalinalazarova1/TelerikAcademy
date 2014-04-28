//14 * We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x). 
//We can move from an empty cell to another empty cell if they share common wall. Given a starting position
//(*) calculate and fill in the array the minimal distance from this position to any other cell in the array.
//Use "u" for all unreachable cells.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[,] labyrinth = {{"0","0","0","X","0","X"},
                               {"0","X","0","X","0","X"},
                               {"0","*","X","0","X","0"},
                               {"0","X","0","0","0","0"},
                               {"0","0","0","X","X","0"},
                               {"0","0","0","X","0","X"}};
        int distance = 0;
        if (GetStartingPosition(labyrinth) == null) throw new ApplicationException("The labyrinth has no starting point!");
        int row = GetStartingPosition(labyrinth).Item1;
        int col = GetStartingPosition(labyrinth).Item2;
        var cells = new Queue<Cell>();
        cells.Enqueue(new Cell(row, col, distance));
        while (cells.Count > 0)
        {
            distance++;
            var current = cells.Dequeue();
            if (labyrinth[current.Row, current.Col] != "*")
            {
                labyrinth[current.Row, current.Col] = current.Distance.ToString();
            }
            if (IsPossible(labyrinth, new Cell(current.Row + 1, current.Col, current.Distance + 1)))
            {
                cells.Enqueue(new Cell(current.Row + 1, current.Col, current.Distance + 1));
            }
            if (IsPossible(labyrinth, new Cell(current.Row, current.Col + 1, current.Distance + 1)))
            {
                cells.Enqueue(new Cell(current.Row, current.Col + 1, current.Distance + 1));
            }
            if (IsPossible(labyrinth, new Cell(current.Row - 1, current.Col, current.Distance + 1)))
            {
                cells.Enqueue(new Cell(current.Row - 1, current.Col, current.Distance + 1));
            }
            if (IsPossible(labyrinth, new Cell(current.Row, current.Col - 1, current.Distance + 1)))
            {
                cells.Enqueue(new Cell(current.Row, current.Col - 1, current.Distance + 1));
            }
        }

        for (int r = 0; r < labyrinth.GetLength(0); r++)
        {
            for (int c = 0; c < labyrinth.GetLength(1); c++)
            {
                Console.Write("{0, 3}", labyrinth[r, c] == "0" ? "U" : labyrinth[r, c]);
            }
            Console.WriteLine();
        }
    }

    static Tuple<int, int> GetStartingPosition(string[,] labyrinth)
    {
        for (int r = 0; r < labyrinth.GetLength(0); r++)
        {
            for (int c = 0; c < labyrinth.GetLength(1); c++)
            {
                if (labyrinth[r, c] == "*")
                {
                    return new Tuple<int, int>(r, c);
                }
            }
        }
        return null;
    }

    static bool IsPossible(string[,] labyrinth, Cell cur)
    {
        if ((cur.Row < labyrinth.GetLength(0) && cur.Row >= 0 && cur.Col < labyrinth.GetLength(1) && cur.Col >= 0)
            && labyrinth[cur.Row, cur.Col] == "0")
        {
            return true;
        }
        return false;
    }
}

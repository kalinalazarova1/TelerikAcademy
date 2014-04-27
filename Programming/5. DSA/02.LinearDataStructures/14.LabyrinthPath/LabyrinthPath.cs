//14 * We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x). 
//We can move from an empty cell to another empty cell if they share common wall. Given a starting position
//(*) calculate and fill in the array the minimal distance from this position to any other cell in the array.
//Use "u" for all unreachable cells.

//TODO: Implement it with queue.

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
        int depth = 0;
        if (GetStartingPosition(labyrinth) == null) throw new ApplicationException("The labyrinth has no starting point!");
        int row = GetStartingPosition(labyrinth).Item1;
        int col = GetStartingPosition(labyrinth).Item2;
        
        Move(labyrinth, row + 1, col, depth + 1);
        Move(labyrinth, row, col + 1, depth + 1);
        Move(labyrinth, row - 1, col, depth + 1);
        Move(labyrinth, row, col - 1, depth + 1);
        
        for (int r = 0; r < labyrinth.GetLength(0); r++)
        {
            for (int c = 0; c < labyrinth.GetLength(1); c++)
            {
                Console.Write("{0, 3}", labyrinth[r, c] == "0" ? "U" : labyrinth[r, c]);
            }
            Console.WriteLine();
        }
    }

    static void Move(string[,] labyrinth, int r, int c, int depth)
    {
        if (r >= labyrinth.GetLength(0) || r < 0 || c >= labyrinth.GetLength(1) || c < 0 ) return;
        if (labyrinth[r, c] == "X" || labyrinth[r, c] == "*") return;
        if (labyrinth[r, c] != "0" && int.Parse(labyrinth[r, c]) <= depth) return;
        labyrinth[r, c] = depth.ToString();
        Move(labyrinth, r + 1, c, depth + 1);
        Move(labyrinth, r, c + 1, depth + 1);
        Move(labyrinth, r - 1, c, depth + 1);
        Move(labyrinth, r, c - 1, depth + 1);
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
}

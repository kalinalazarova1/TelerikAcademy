// 4. Refactor and improve the naming in the C# source project “3. Naming-Identifiers-Homework.zip”.
// You are allowed to make other improvements in the code as well (not only naming) as well as to fix bugs.

namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private const int BoardRows = 5;     // if rows count is more than 10 the command parsing have to be improved
        private const int BoardColumns = 10;
        private const int MinesCount = 15;

        internal static void Main(string[] args)
        {
            const int ScoresTableRows = 5;

            int freeCellsCount = (BoardRows * BoardColumns) - MinesCount;
            string command = string.Empty;
            char[,] board = GenerateInitialBoard();
            char[,] mines = GenerateMines();
            int openedCells = 0;
            List<Score> championsTable = new List<Score>(ScoresTableRows + 1);
            int currentRow = 0;
            int currentCol = 0;
            bool isGameStart = true;
            bool isGameWon = false;
            bool isGameLost = false;

            do
            {
                if (isGameStart)
                {
                    Console.WriteLine(@"Това е играта “Minesweeper”. Опитайте да откриете полетата без мини.

        КОМАНДИ:
        Команда top - показва класирането,
        Команда restart - започва нова игра
        Команда exit - край на играта");
                    DrawCurrentBoard(board);
                    isGameStart = false;
                }

                Console.Write("Моля, команда или въведете ред и колона: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out currentRow) &&
                        int.TryParse(command[2].ToString(), out currentCol) &&
                        currentRow < board.GetLength(0) &&
                        currentCol < board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        DrawStandingsTable(championsTable);
                        break;
                    case "restart":
                        board = GenerateInitialBoard();
                        mines = GenerateMines();
                        DrawCurrentBoard(board);
                        isGameLost = false;
                        isGameStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Довиждане!");
                        break;
                    case "turn":
                        if (mines[currentRow, currentCol] != '*')
                        {
                            if (mines[currentRow, currentCol] == '-')
                            {
                                FillMinesCount(board, mines, currentRow, currentCol);
                                openedCells++;
                            }

                            if (freeCellsCount == openedCells)
                            {
                                isGameWon = true;
                            }
                            else
                            {
                                DrawCurrentBoard(board);
                            }
                        }
                        else
                        {
                            isGameLost = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nНевалидна команда!\n");
                        break;
                }

                if (isGameLost)
                {
                    DrawCurrentBoard(mines);
                    Console.Write("\nБуум! Стъпихте на мина и завършвате играта с {0} точки.\nМоля, въведете име: ", openedCells);
                    string playersName = Console.ReadLine();
                    Score currentScore = new Score(playersName, openedCells);
                    if (championsTable.Count < ScoresTableRows)
                    {
                        championsTable.Add(currentScore);
                    }
                    else
                    {
                        for (int i = 0; i < championsTable.Count; i++)
                        {
                            if (championsTable[i].Points < currentScore.Points)
                            {
                                championsTable.Insert(i, currentScore);
                                championsTable.RemoveAt(championsTable.Count - 1);
                                break;
                            }
                        }
                    }

                    championsTable.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    championsTable.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    DrawStandingsTable(championsTable);

                    board = GenerateInitialBoard();
                    mines = GenerateMines();
                    openedCells = 0;
                    isGameLost = false;
                    isGameStart = true;
                }

                if (isGameWon)
                {
                    Console.WriteLine("\nБраво! Отворихте 35 клетки без да стъпите на мина.");
                    DrawCurrentBoard(mines);
                    Console.WriteLine("Моля, въведете име: ");
                    string playersName = Console.ReadLine();
                    Score currentScore = new Score(playersName, openedCells);
                    championsTable.Add(currentScore);
                    DrawStandingsTable(championsTable);
                    board = GenerateInitialBoard();
                    mines = GenerateMines();
                    openedCells = 0;
                    isGameWon = false;
                    isGameStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Натиснете клавиш за изход!");
            Console.Read();
        }

        private static void DrawStandingsTable(List<Score> pointsTable)
        {
            Console.WriteLine("\nКЛАСИРАНЕ:");
            if (pointsTable.Count > 0)
            {
                for (int i = 0; i < pointsTable.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} точки", i + 1, pointsTable[i].Name, pointsTable[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Класацията е празна!\n");
            }
        }

        private static void FillMinesCount(char[,] board, char[,] mines, int row, int col) // fills in the current cell the mines' count that surround the current opened position
        {
            char surroundMinesCount = GetSurroundingMines(mines, row, col);
            mines[row, col] = surroundMinesCount;
            board[row, col] = surroundMinesCount;
        }

        private static void DrawCurrentBoard(char[,] board)
        {
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int r = 0; r < BoardRows; r++)
            {
                Console.Write("{0} | ", r);
                for (int j = 0; j < BoardColumns; j++)
                {
                    Console.Write(string.Format("{0} ", board[r, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GenerateInitialBoard()
        {
            char[,] board = new char[BoardRows, BoardColumns];
            for (int r = 0; r < BoardRows; r++)
            {
                for (int c = 0; c < BoardColumns; c++)
                {
                    board[r, c] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateMines()
        {
            char[,] mines = new char[BoardRows, BoardColumns];

            for (int r = 0; r < BoardRows; r++)
            {
                for (int c = 0; c < BoardColumns; c++)
                {
                    mines[r, c] = '-';
                }
            }

            List<int> minesPositions = new List<int>();
            while (minesPositions.Count < MinesCount)
            {
                Random random = new Random();
                int position = random.Next(BoardRows * BoardColumns);
                if (!minesPositions.Contains(position))
                {
                    minesPositions.Add(position);
                }
            }

            foreach (int position in minesPositions)
            {
                int mineRow = position / BoardColumns;
                int mineColumn = position % BoardColumns;
                mines[mineRow, mineColumn] = '*';
            }

            return mines;
        }

        private static char GetSurroundingMines(char[,] mines, int curRow, int curCol)  // calculates the surrounding mines and returns the result as char because it has to be filled in char matrix
        {
            int minesCount = 0;
            
            if (curRow - 1 >= 0)
            {
                if (mines[curRow - 1, curCol] == '*')
                {
                    minesCount++;
                }
            }

            if (curRow + 1 < BoardRows)
            {
                if (mines[curRow + 1, curCol] == '*')
                {
                    minesCount++;
                }
            }

            if (curCol - 1 >= 0)
            {
                if (mines[curRow, curCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (curCol + 1 < BoardColumns)
            {
                if (mines[curRow, curCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((curRow - 1 >= 0) && (curCol - 1 >= 0))
            {
                if (mines[curRow - 1, curCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((curRow - 1 >= 0) && (curCol + 1 < BoardColumns))
            {
                if (mines[curRow - 1, curCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((curRow + 1 < BoardRows) && (curCol - 1 >= 0))
            {
                if (mines[curRow + 1, curCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((curRow + 1 < BoardRows) && (curCol + 1 < BoardColumns))
            {
                if (mines[curRow + 1, curCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}

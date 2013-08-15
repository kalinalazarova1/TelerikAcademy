using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class TicTacToe
{
    static void DrawBoard(int[,] board, int[] cur, int offsetX, int offsetY) // draws the board initially with appropriate offset
    {
        Console.SetCursorPosition(0, offsetY);
        for (int r = 0; r < 3; r++)
        {
            Console.Write("{0}", new string(' ', offsetX));
            Console.WriteLine("-------");
            Console.Write("{0}", new string(' ', offsetX));
            for (int c = 0; c < 3; c++)
            {
                Console.Write('|');
                if(board[r, c] == 1)
                {
                    Console.Write('O');
                }
                else if (board[r, c] == -1)
                {
                    Console.Write('X');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine('|');
        }
        Console.Write("{0}", new string(' ', offsetX));
        Console.WriteLine("-------");
        Console.Write("Press Esc for exit");
        Console.SetCursorPosition(offsetX + 1 + cur[1] * 2, offsetY + 1 + cur[0] * 2); 
    }

    static void DrawInfo(int[] games) //draws the result when new game starts
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(" Games won : Games lost");//Draw info;
        Console.WriteLine("        {0} : {1}", games[0], games[1]);
    }

    public static void RemoveScrollBars(int width, int heigth) //resizes game window
    {
        Console.BufferHeight = Console.WindowHeight = heigth;       //clear the left scroll bar
        Console.BufferHeight = Console.WindowWidth = width;         //clear the down scroll bar
        Console.Title = "TicTacToe";
    }

    static void Play(int[,] board, int[] cur, int[] games, int gamesPlayed) //takes player move or allows a computer to play 
    {
        if (gamesPlayed % 2 == 1 && GetTotalMoves(board) == 0) //decides who will start first
        {
            PlayComputer(board);
            DrawBoard(board, cur, 8, 3);
        }
        ConsoleKeyInfo pressedKey = Console.ReadKey(true); //reads the player move
        switch (pressedKey.Key)
        {
            case ConsoleKey.DownArrow:      //arrow keys move the current position of the cursor
                if (cur[0] < board.GetLength(0) - 1)
                {
                    cur[0]++;
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop += 2);
                }
                break;
            case ConsoleKey.Enter:      //draws player sign in the current position and if not game over calls PlayComputer()
                if (board[cur[0], cur[1]] == 0)
                {
                    board[cur[0], cur[1]] = 1;
                    Console.Write('O');
                    Console.SetCursorPosition(--Console.CursorLeft, Console.CursorTop);
                    Thread.Sleep(500);
                    if (!IsWon(board) && !IsLost(board) && GetTotalMoves(board) < 9)
                    {
                        PlayComputer(board);
                    }
                }
                break;
            case ConsoleKey.LeftArrow:
                if (cur[1] > 0)
                {
                    cur[1]--;
                    Console.SetCursorPosition(Console.CursorLeft -= 2, Console.CursorTop);
                }
                break;
            case ConsoleKey.RightArrow:
                if (cur[1] < board.GetLength(1) - 1)
                {
                    cur[1]++;
                    Console.SetCursorPosition(Console.CursorLeft += 2, Console.CursorTop);
                }
                break;
            case ConsoleKey.UpArrow:
                if (cur[0] > 0)
                {
                    cur[0]--;
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop -= 2);
                }
                break;
            case ConsoleKey.Escape:     //Esc for exit of the game
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }

    static void PlayComputer(int[,] board) //the global strategy for the computer in the play
    {
        if (GetTotalMoves(board) < 2)   //computer always starts in the middle or in the up left corner and always wins
        {
            if (board[1, 1] == 0)
            {
                board[1, 1] = -1;
                return;
            }
            else
            {
                board[0, 0] = -1;
                return;
            }
            /*Random ranGen = new Random(); //if we want random first move from the computer and then it is possible the computer to lose
            int i;
            int j;
            do
            {
                i = ranGen.Next(0, 3);
                j = ranGen.Next(0, 3);
            }
            while (board[i, j] != 0);
            board[i, j] = -1;
            return;*/
        }
        else if (GetTotalMoves(board) == 3 && (board[0, 0] + board[2, 2] == 2 || board[0, 2] + board[2, 0] == 2))
        {
            board[0, 1] = -1;   //first special case when playing the clearest corner is not a good strategy
            return;
        }
        else if (GetTotalMoves(board) == 3 && (board[0, 1] + board[1, 2] == 2))
        {
            board[0, 2] = -1;   //second special case when playing a corner is not a good strategy;
            return;
        }
        else if (GetTotalMoves(board) == 3 && (board[1, 2] + board[2, 1] == 2))
        {
            board[2, 2] = -1;
            return;
        }
        else if (GetTotalMoves(board) == 3 && (board[2, 1] + board[1, 0] == 2))
        {
            board[2, 0] = -1;
            return;
        }
        else if (GetTotalMoves(board) == 3 && (board[1, 0] + board[0, 1] == 2))
        {
            board[0, 0] = -1;
            return;
        }
        else
        {
            if (IsWinningStrategy(board))   //first checks for possible win (two 'X' symbols and one empty cell)
            {
                return;
            }
            else if (IsDefenceStrategy(board)) //then checks for possible loss (two 'O' symbols and one empty cell)
            {
                return;
            }
            else
            {
                AttackStrategy(board); //is the first two are not played then try to make the best move to take initiative;
            }
        }
    }

    static int GetTotalMoves(int[,] board) //counts the total moves in the current game
    {
        int counter = 0;
        for (int r = 0; r < 3; r++)
		{
			for (int c = 0; c < 3; c++)
			{
                if (board[r, c] != 0)
                {
                    counter++;
                }
			}
		}
        return counter;
    }

    static bool IsWinningStrategy(int[,] board) //makes a line if possible and returns true else returns false;
    {
        int sum;
        sum = board[0, 0] + board[1, 1] + board[2, 2];
        if (sum == -2)
        {
            if (board[0, 0] == 0) board[0, 0] = -1;
            else if (board[1, 1] == 0) board[1, 1] = -1;
            else if (board[2, 2] == 0) board[2, 2] = -1;
            return true;
        }
        sum = board[0, 2] + board[1, 1] + board[2, 0];
        if (sum == -2)
        {
            if (board[0, 2] == 0) board[0, 2] = -1;
            else if (board[2, 0] == 0) board[2, 0] = -1;
            return true;
        }
        for (int r = 0; r < 3; r++)
        {
            sum = board[r, 0] + board[r, 1] + board[r, 2];
            if (sum == -2)
            {
                if (board[r, 0] == 0) board[r, 0] = -1;
                else if (board[r, 1] == 0) board[r, 1] = -1;
                else if (board[r, 2] == 0) board[r, 2] = -1;
                return true;
            }
        }
        for (int c = 0; c < 3; c++)
        {
            sum = board[0, c] + board[1, c] + board[2, c];
            if (sum == -2)
            {
                if (board[0, c] == 0) board[0, c] = -1;
                else if (board[1, c] == 0) board[1, c] = -1;
                else if (board[2, c] == 0) board[2, c] = -1;
                return true;
            }
        }
        return false;
    }

    static bool IsDefenceStrategy(int[,] board) //prevents the player to make a line if available and returns true else returns false;
    {
        int sum;
        sum = board[0, 0] + board[1, 1] + board[2, 2];
        if (sum == 2)
        {
            if (board[0, 0] == 0) board[0, 0] = -1;
            else if (board[1, 1] == 0) board[1, 1] = -1;
            else if (board[2, 2] == 0) board[2, 2] = -1;
            return true;
        }
        sum = board[0, 2] + board[1, 1] + board[2, 0];
        if (sum == 2)
        {
            if (board[0, 2] == 0) board[0, 2] = -1;
            else if (board[2, 0] == 0) board[2, 0] = -1;
            return true;
        }
        for (int r = 0; r < 3; r++)
        {
            sum = board[r, 0] + board[r, 1] + board[r, 2];
            if (sum == 2)
            {
                if (board[r, 0] == 0) board[r, 0] = -1;
                else if (board[r, 1] == 0) board[r, 1] = -1;
                else if (board[r, 2] == 0) board[r, 2] = -1;
                return true;
            }
        }
        for (int c = 0; c < 3; c++)
        {
            sum = board[0, c] + board[1, c] + board[2, c];
            if (sum == 2)
            {
                if (board[0, c] == 0) board[0, c] = -1;
                else if (board[1, c] == 0) board[1, c] = -1;
                else if (board[2, c] == 0) board[2, c] = -1;
                return true;
            }
        }
        return false;
    }

    static void AttackStrategy(int[,] board) //first chooses the best corner if not then chooses an empty corner if not chooses an empty side
    {
        int[] bestAngle = { board[0, 1] + board[1, 0], board[0, 1] + board[1, 2], board[2, 1] + board[1, 2] + board[2, 1] + board[1, 0] };
        switch (Array.IndexOf(bestAngle, bestAngle.Max()))
        {
            case 0: if (board[2, 2] == 0)
                {
                    board[2, 2] = -1;
                    return;
                }
                else break;
            case 1: if (board[2, 0] == 0)
                {
                    board[2, 0] = -1;
                    return;
                }
                else break;
            case 2: if (board[0, 0] == 0)
                {
                    board[0, 0] = -1;
                    return;
                }
                else break;
            case 3: if (board[0, 2] == 0)
                {
                    board[0, 2] = -1;
                    return;
                }
                else break;
            default: break;
        }
        if (board[0, 0] == 0) board[0, 0] = -1;
        else if(board[2, 2] == 0) board[2, 2] = -1;
        else if (board[0, 2] == 0) board[0, 2] = -1;
        else if (board[2, 0] == 0) board[2, 0] = -1;
        else
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (board[r, c] == 0)
                    {
                        board[r, c] = -1;
                        return;
                    }
                }
            }
        }
    }

    static bool IsWon(int[,] board) //returns true if there is a line with three equal 'O'
    {
        int sumDiagFirst = board[0,0] + board[1,1] + board[2,2];
        int sumDiagSecond = board[0,2] + board[1,1] + board[2,0];
        for (int i = 0; i < 3; i++)
        {
            int sumVert = 0;
            int sumHor = 0;
            for (int j = 0; j < 3; j++)
            {
                sumVert += board[j, i];
                sumHor += board[i, j];
            }
            if (sumVert == 3 || sumHor == 3 || sumDiagFirst == 3 || sumDiagSecond == 3)
            {
                return true;
            }
        }
        return false;
    }

    static bool IsLost(int[,] board) //returns true if there is a line with three equal 'X'
    {
        int sumDiagFirst = board[0, 0] + board[1, 1] + board[2, 2];
        int sumDiagSecond = board[0, 2] + board[1, 1] + board[2, 0];
        for (int i = 0; i < 3; i++)
        {
            int sumVert = 0;
            int sumHor = 0;
            for (int j = 0; j < 3; j++)
            {
                sumVert += board[j, i];
                sumHor += board[i, j];
            }
            if (sumVert == -3 || sumHor == -3 || sumDiagFirst == -3 || sumDiagSecond == -3)
            {
                return true;
            }
        }
        return false;
    }

    static void GameOver(int[,] board, int[] games, int[] current) //Changes result, waits for key and starts new game
    {
        if (IsWon(board)) games[0]++;
        else if (IsLost(board)) games[1]++;
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(" Games won : Games lost");//Draw info;
        Console.WriteLine("        {0} : {1}", games[0], games[1]);
        Console.ReadKey(true);
        ClearBoard(board);
        current[0] = 1;
        current[1] = 1;
    }

    static void ClearBoard(int[,] board) //clears all symbols from the board
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                board[r, c] = 0;
            }
        }
    }

    static void Main()
    {
        int gamesPlayed = 0;  //total games played including draw games
        int[] games = {0, 0}; //games won and lost
        int[] current = { 1, 1}; //current position coordinates
        RemoveScrollBars(30, 11);
        DrawInfo(games);
        int[,] board = new int[3,3];
        DrawBoard(board, current, 8, 3);
        while(true)
        {
        Play(board, current, games, gamesPlayed);
        DrawBoard(board, current, 8, 3);
        if (IsWon(board)|| IsLost(board) || GetTotalMoves(board) == 9)
            {
                GameOver(board, games, current);
                gamesPlayed++;
                DrawBoard(board, current, 8, 3);
            }
        }
    }
}

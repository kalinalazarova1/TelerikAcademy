namespace _05.TicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class TicTacToeAI
    {
        public void PlayComputer(int[,] board) //the global strategy for the computer in the play
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

        public bool IsWon(int[,] board) //returns true if there is a line with three equal 'O'
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
                if (sumVert == 3 || sumHor == 3 || sumDiagFirst == 3 || sumDiagSecond == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsLost(int[,] board) //returns true if there is a line with three equal 'X'
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

        public void ClearBoard(int[,] board) //clears all symbols from the board
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    board[r, c] = 0;
                }
            }
        }

        private int GetTotalMoves(int[,] board) //counts the total moves in the current game
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

        private bool IsWinningStrategy(int[,] board) //makes a line if possible and returns true else returns false;
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

        private bool IsDefenceStrategy(int[,] board) //prevents the player to make a line if available and returns true else returns false;
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

        private void AttackStrategy(int[,] board) //first chooses the best corner if not then chooses an empty corner if not chooses an empty side
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
            else if (board[2, 2] == 0) board[2, 2] = -1;
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
    }
}
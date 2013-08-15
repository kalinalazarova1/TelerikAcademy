using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.IO;

class Program
{
    static void Play(int[,] field, ConsoleColor[] colors, ConsoleColor[] selectedColours, int[] cur, int[] sel)
    {
        if (Console.KeyAvailable)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (cur[0] < field.GetLength(0) - 1) cur[0]++;
                        break;
                    case ConsoleKey.Enter:
                        SelectBall(field, colors, selectedColours, cur, sel);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cur[1] > 0) cur[1]--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (cur[1] < field.GetLength(1) - 1) cur[1]++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (cur[0] > 0) cur[0]--;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    static void SelectBall(int[,] field, ConsoleColor[] colors, ConsoleColor[] selectedColours, int[] cur, int[] sel)
    {
        if (sel[1] == -1 && sel[0] == -1 && field[cur[0],cur[1]] != 1)
        {
            sel[1] = cur[1];
            sel[0] = cur[0];
        }
        else if (sel[0] == cur[0] && sel[1] == cur[1])
        {
            sel[1] = -1;
            sel[0] = -1;
        }
        else
        {
            if (field[cur[0], cur[1]] != 1)
            {
                ExchangeBalls(field, colors, selectedColours, cur, sel);
            }
        }
    }

    static void ExchangeBalls(int[,] field, ConsoleColor[] colors, ConsoleColor[] selectedColours, int[] cur, int[] sel)
    {
        if((cur[1] == sel[1] - 1 && cur[0] == sel[0]) || (cur[1] == sel[1] + 1 && cur[0] == sel[0])|| (cur[1] == sel[1] && cur[0] == sel[0] + 1) || (cur[1] == sel[1] && cur[0] == sel[0] - 1))
        {
            SwapBalls(field, cur[1], cur[0], sel[1], sel[0]);
            DrawField(field, colors, selectedColours, cur, sel);
            Thread.Sleep(500);
            if (!LinesAreAvailable(field))
            {
                SwapBalls(field, cur[1], cur[0], sel[1], sel[0]);
                DrawField(field, colors, selectedColours, cur, sel);
            }
            else
            {
                while (LinesAreAvailable(field))
                {
                    DeleteEqualBalls(field, colors, selectedColours, cur, sel);
                    if (!IsPossibleToPlay(field))
                    {
                        GenerateField(field, colors);
                    }
                }
            }
            sel[0] = sel[1] = - 1;
        }
    }

    static void DeleteEqualBalls(int[,] field, ConsoleColor[] colors, ConsoleColor[] selectedColours, int[] cur, int[] sel)
    {
        for (int r = 0; r < field.GetLength(0); r++)
        {
            for (int c = 0; c < field.GetLength(1); c++)
            {
                FindEqualBalls(field, r, c);
            }
        }
        sel[0] = sel[1] = -1;
        cur[0] = field.GetLength(0) / 2;
        cur[1] = field.GetLength(1) / 2;
        while (BlackBallsAreAvailable(field))
        {
            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    if (field[r, c] == 0)
                    {
                        if (r != 0)
                        {
                            SwapBalls(field, c, r - 1, c, r);
                            DrawField(field, colors, selectedColours, cur, sel);
                        }
                        else
                        {
                            SwapBalls(field, c, r, new Random().Next(1, colors.Length));
                            DrawField(field, colors, selectedColours, cur, sel);
                        }
                    }
                }
            }
        }
    }

    static void FindEqualBalls(int[,] field, int startRow, int startCol)                                    //Makes the equal colored balls black;
    {
        if(field[startRow, startCol] == 1)
        {
            return;
        }
        int sequence = 0;
        int value = field[startRow, startCol];
        int currentRow = startRow;
        int currentCol = startCol;
        if (startRow <= field.GetLength(0) - 3 && (value == field[currentRow + 1, currentCol] && value == field[currentRow + 2, currentCol]))       //check horizontally if there are 3 equal balls
        {
            for (currentRow = startRow; IsInside(field, currentRow, currentCol) && value == field[currentRow, currentCol]; currentRow++)
            {
                field[currentRow, currentCol] = 0;
                ballsCount++;
                sequence++;
            }
            score += (sequence * 5) * (sequence - 2);
        }
        currentRow = startRow;
        sequence = 0;
        if (startCol <= field.GetLength(1) - 3 && (value == field[currentRow, currentCol + 1] && value == field[currentRow, currentCol + 2]))         //check vertically if there are 3 equal balls
        {
            for (currentCol = startCol; IsInside(field, currentRow, currentCol) && value == field[currentRow, currentCol]; currentCol++)
            {
                field[currentRow, currentCol] = 0;
                ballsCount++;
                sequence++;
            }
            score += (sequence * 5) * (sequence - 2);
        }
    }

    static bool IsInside(int[,] arr, int r, int c)
    {
        if (r >= 0 && r < arr.GetLength(0) && c >= 0 && c < arr.GetLength(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void SwapBalls(int[,] field, int sourceX, int sourceY, int destX, int destY)
    {
        int temp = field[sourceY, sourceX];
        field[sourceY, sourceX] = field[destY, destX];
        field[destY, destX] = temp;
    }

    static void SwapBalls(int[,] field, int sourceX, int sourceY, int newValue)
    {
        int temp = field[sourceY, sourceX];
        field[sourceY, sourceX] = newValue;
        newValue= temp;
    }

    static bool BlackBallsAreAvailable(int[,] field)
    {
        for (int r = 0; r < field.GetLength(0); r++)
        {
            for (int c = 0; c < field.GetLength(1); c++)
            {
                if (field[r, c] == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool LinesAreAvailable(int[,] field)
    {
        for (int r = 0; r < field.GetLength(0) - 2; r++)
        {
            for (int c = 0; c < field.GetLength(1); c++)
            {
                if (field[r, c] == field[r + 1, c] && field[r, c] == field[r + 2, c] && field[r, c] != 1)
                {
                    return true;
                }
            }
        }
        for (int r = 0; r < field.GetLength(0); r++)
        {
            for (int c = 0; c < field.GetLength(1) - 2; c++)
            {
                if (field[r, c] == field[r, c + 1] && field[r, c] == field[r, c + 2] && field[r, c] != 1)
                {
                    return true;
                }
            }
        } 
        return false;
    }

    static bool IsPossibleToPlay(int[,] field)
    {
        for (int r = 0; r < field.GetLength(0); r++)
        {
            for (int c = 0; c < field.GetLength(1); c++)
            {
                if (IsInside(field, r, c + 1))
                {
                    SwapBalls(field, c, r, c + 1, r);
                    if (LinesAreAvailable(field))
                    {
                        SwapBalls(field, c, r, c + 1, r);
                        return true;
                    }
                    SwapBalls(field, c, r, c + 1, r);
                }
                if(IsInside(field, r + 1, c))
                {
                    SwapBalls(field, c, r, c, r + 1);
                    if (LinesAreAvailable(field))
                    {
                        SwapBalls(field, c, r, c, r + 1);
                        return true;
                    }
                    SwapBalls(field, c, r, c, r + 1);               
                }
            }
        }
        return false;
    }

    static void GenerateField(int[,] field, ConsoleColor[] colours)
    {
        Random randIndex = new Random();
        for (int r = 0; r < field.GetLength(0); r++)
        {
            for (int c = 0; c < field.GetLength(1); c++)
            {
                field[r, c] = randIndex.Next(2, colours.Length);
            }
        }
        while (LinesAreAvailable(field) || !IsPossibleToPlay(field))
        {
            int randX = randIndex.Next(0, field.GetLength(1) - 1);
            int randY = randIndex.Next(0, field.GetLength(0));
            SwapBalls(field, randX, randY, randX + 1, randY);
        }
    }

    static void DrawField(int[,] field, ConsoleColor[] colors, ConsoleColor[] selectedCol, int[] cur, int[] sel)
    {
        
        for (int r = 0; r < field.GetLength(0); r++)
        {
            Console.SetCursorPosition(1, r + 1);
            for (int c = 0; c < field.GetLength(1); c++)
            {
                if ((r == cur[0] && c == cur[1]) && (r == sel[0] && c == sel[1]))
                {
                    Console.ForegroundColor = selectedCol[field[r, c]];
                    Console.Write('*');
                }
                else if (r == cur[0] && c == cur[1])
                {
                    Console.ForegroundColor = colors[field[r, c]];
                    Console.Write('*');
                }
                else if (r == sel[0] && c == sel[1])
                {
                    Console.ForegroundColor = selectedCol[field[r, c]];
                    Console.Write('@');
                }
                else
                {
                    Console.ForegroundColor = colors[field[r, c]];
                    Console.Write('@');
                }
            }
        }
    }

    public static void RemoveScrollBars(int width, int heigth)
    {
        Console.BufferHeight = Console.WindowHeight = heigth;       //clear the left scroll bar
        Console.BufferHeight = Console.WindowWidth = width;         //clear the down scroll bar
    }

    static DateTime StartGame()
    {
        RemoveScrollBars(36, 12);
        Console.Title = "Bounce Out";
        Console.SetCursorPosition(5, 5);
        Console.WriteLine("GAME BOUNCE OUT");
        Console.SetCursorPosition(5, 7);
        Console.WriteLine("Press a key to start...");
        Console.ReadKey(true);
        Console.Clear();
        return DateTime.Now;
    }
    //Draws initial menu;
    //Waits for start key pressed;
    //Starts time measure;

    public static void DrawCharOnPosition(int x, int y, char c, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

    static void DrawInfo(int[,] field)
    {
        for (int i = 0; i < field.GetLength(0) + 2; i++)
        {
            DrawCharOnPosition(0, i, '|', ConsoleColor.White);
            DrawCharOnPosition(field.GetLength(1) + 1, i, '|', ConsoleColor.White);
        }
        for (int i = 1; i < field.GetLength(1) + 1; i++)
        {
            DrawCharOnPosition(i, 0, '=', ConsoleColor.White);
            DrawCharOnPosition(i, field.GetLength(0) + 1, '=', ConsoleColor.White);
        }
        Console.SetCursorPosition(15, 3);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Level {0}: {1} balls", level, level * 10 + 10);
        Console.SetCursorPosition(15, 5);
        Console.WriteLine("Score: {0}", score);
        Console.SetCursorPosition(15, 7);
        Console.WriteLine("Balls: {0}", ballsCount.ToString().PadLeft(2,'0'));
        Console.SetCursorPosition(15, 9);
        Console.WriteLine("Time: {0}:{1}", startTime.AddMinutes(1).Subtract(DateTime.Now).Minutes, startTime.AddMinutes(1).Subtract(DateTime.Now).Seconds.ToString().PadLeft(2,'0'));
    }
    //Draws scoresheet;

    static void CheckTimeAndBalls(int[,] field, ConsoleColor[] colours)
    {
        
        if (ballsCount >= level * 10 + 10)
        {
            GenerateField(field, colours);
            ballsCount = 0;
            level++;
            startTime = DateTime.Now;
        }
        if (DateTime.Now.CompareTo(startTime.AddMinutes(1)) == 1)
        {
            GameOver(field);
        }
    }
    //Checks time if out of the limit -> calls method GameOver();
    //checks if ballsCount reached the required -> calls method GenerateField() and level++;

    static void GameOver(int[,] field)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(13, 1);
        Console.WriteLine("GAME OVER!!!");
        DrawInfo(field);
        Console.WriteLine("Press a key to exit...");
        Console.ReadKey(true);
        List<int> results = new List<int>();
        List<string> names = new List<string>();
        string[] players;
        int[] scores;
        string playerName = string.Empty;
        if (!File.Exists("result.txt"))
        {
            using (File.Create("result.txt"));
        }
        using (StreamReader reader = new StreamReader("result.txt"))
        {
            char[] separator = {'#','\t','\r','\n'};
            string all = reader.ReadToEnd();
            string[] words = all.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 20 || int.Parse(words[words.Length - 1]) < score)
            {
                for (int i = 0; i < words.Length; i += 2)
                {
                    names.Add(words[i]);
                    results.Add(int.Parse(words[i + 1]));
                }
                results.Add(score);
                Console.Clear();
                Console.WriteLine("Please input your name:");
                names.Add(Console.ReadLine() + " ");
            }
            else
            {
                Environment.Exit(0);
            }
        }
        using (StreamWriter writer = new StreamWriter("result.txt"))
        {
            players = names.ToArray();
            scores = results.ToArray();
            Array.Sort(scores, players, 0, results.Count);
            Array.Reverse(players);
            Array.Reverse(scores);
            Console.Clear();
            Console.WriteLine("Ten Best Scores:");
            for (int i = 0; i < (scores.Length > 10 ? 10 : scores.Length); i++)
            {
                writer.WriteLine("#\t{0}\t#\t{1}\t#", players[i], scores[i]);
                Console.WriteLine("{0,2}. {1,-15} - {2,7} points", i + 1, players[i], scores[i]);
            }
        }
        Environment.Exit(0);
    }
    //Draws the final score and exit menu, if the score is top 10 writes result to file;

    static int level = 0;
    static int score = 0;
    static int ballsCount = 0;
    static DateTime startTime;

    static void Main()
    {
        int playfieldWidth = 10;
        int playfieldHeigth = 10;
        ConsoleColor[] colours = { ConsoleColor.Black, ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Yellow };
        ConsoleColor[] selectedColours = { ConsoleColor.Black, ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray, ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.DarkYellow };
        int[,] field = new int[playfieldHeigth, playfieldWidth];
        int[] current = { field.GetLength(0) / 2, field.GetLength(1) / 2 };
        int[] selected = {-1, -1};
        try
        {
            startTime = StartGame();
            GenerateField(field, colours);
            while (true)
            {
                DrawField(field, colours, selectedColours, current, selected);
                DrawInfo(field);
                Play(field, colours, selectedColours, current, selected);
                CheckTimeAndBalls(field, colours);
                Thread.Sleep(500);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

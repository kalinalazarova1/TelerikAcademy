using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;

class BounceOut                 
{
    static void ConsoleInitialSettings(int playfieldHeight, int playfieldWidth)
    {
        Console.BufferHeight = Console.WindowHeight = playfieldHeight + 10;
        Console.BufferWidth = Console.WindowWidth = playfieldWidth + 20;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Title = "Bounce Out Ball";
        Console.CursorVisible = false;
    } //sets the initial setting of the console such as title, size

    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    } //prints a string on the console in position set by coordinates

    static void ReadFile(string fileName)
    {
        string content = File.ReadAllText(fileName);
        Console.WriteLine(content);        
    } //reads an external text file

    static void StartGame(int playfieldHeight, int playfieldWidth) 
    {
        ConsoleInitialSettings(playfieldHeight, playfieldWidth);
        PrintStringOnPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 - 8, "Bounce Out Ball", ConsoleColor.Magenta);
        PrintStringOnPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2 - 5, "Menu");
        PrintStringOnPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 3, "New game - press key Enter");
        PrintStringOnPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 1, "Help - press key H");
        PrintStringOnPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 1, "Exit - press key Escape");
        Thread.Sleep(25);
        Console.Beep(222, 125);
        Thread.Sleep(25);
        Console.Beep(111, 325);
        Thread.Sleep(25);
        Console.Beep(444, 125);
        Thread.Sleep(25);
        Console.Beep(666, 925);
        Thread.Sleep(25);
        bool commandCorrect = false;
        while (!commandCorrect)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            while (Console.KeyAvailable) Console.ReadKey(true);
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Beep();
                Console.Clear();
                sw.Start();
                DrawInfo(time, score, ballsCount, playfieldHeight, playfieldWidth);                
                commandCorrect = true;
            }
            else if (pressedKey.Key == ConsoleKey.H)
            {
                Console.Beep();
                Console.Clear();
                string fileName = @"..\..\help.txt";
                ReadFile(fileName);
                PrintStringOnPosition(Console.WindowWidth / 2 - 14, Console.WindowHeight / 2 + 2, "Press key Escape to return!");
                while (!commandCorrect)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        Console.Beep();
                        Console.Clear();
                        StartGame(playfieldHeight, playfieldWidth);
                        commandCorrect = true;
                    }
                    else
                    {
                        PrintStringOnPosition(Console.WindowWidth / 2 - 14, Console.WindowHeight / 2 + 6, "Invalid key! Try again!");
                    }
                }
            }
            else if (pressedKey.Key == ConsoleKey.Escape)
            {
                Console.Beep();
                Console.WriteLine(); 
                Environment.Exit(0); 
                commandCorrect = true; 
            }
            else
            {
                PrintStringOnPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 3, "Invalid key! Try again!");
            }
        }
    } //draws initial menu, waits for key to provide help, exit or starts the game and time measure

    static void GenerateField(int[,] field)
    {
        Random randomGenerator = new Random();
        int rowField = field.GetLength(0);
        int colField = field.GetLength(1);

        do
        {
            for (int i = 0; i < rowField; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    for (int j = 0; j < colField; j++)
                    {
                        field[j, i] = randomGenerator.Next(2, 9);
                    }
                }
                else
                {
                    for (int j = colField - 1; j >= 0; j--)
                    {
                        field[j, i] = randomGenerator.Next(2, 9);
                    }
                }
            }
        }
        while (LinesAreAvailable(field) || !IsPossibleToPlay(field));       
    } //generates random matrix of balls
   
    static void DrawField(int[,] field, ConsoleColor[] colours, ConsoleColor[] selectedColours, int[] current, int[] selected) 
    {
        Console.SetCursorPosition(0, Console.WindowHeight - field.GetLength(0) - 1);
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if ((i == current[0] && j == current[1]) && (i == selected[0] && j == selected[1]))
                {
                    Console.ForegroundColor = selectedColours[field[i, j]];
                    Console.Write('O');
                }
                else if (i == current[0] && j == current[1])
                {
                    Console.ForegroundColor = colours[field[i, j]];
                    Console.Write('O');
                }
                else if (i == selected[0] && j == selected[1])
                {
                    Console.ForegroundColor = selectedColours[field[i, j]];
                    Console.Write('@');
                }
                else
                {
                    Console.ForegroundColor = colours[field[i, j]];
                    Console.Write('@');
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }
    } //draws the generated matrix of balls

    static void DrawInfo(string time, int scores, int ballsCount, int playfieldHeight, int playfieldWidth) 
    {
        ConsoleInitialSettings(playfieldHeight, playfieldWidth);
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            PrintStringOnPosition(playfieldWidth, i, "|");
        }

        PrintStringOnPosition(playfieldWidth + 3, Console.WindowHeight / 2 - 7, "Bounce Out Ball", ConsoleColor.Magenta);
        PrintStringOnPosition(playfieldWidth + 5, Console.WindowHeight / 2 - 4, "Level: " + level);
        PrintStringOnPosition(playfieldWidth + 5, Console.WindowHeight / 2 - 2, "Scores: " + scores);
        PrintStringOnPosition(playfieldWidth + 5, Console.WindowHeight / 2, "Balls: " + ballsCount);
        PrintStringOnPosition(playfieldWidth + 5, Console.WindowHeight / 2 + 2, "Time: " + time);
    } //draws the information for the state of the game

    static void CheckTimeAndBalls(int[,] field, ConsoleColor[] colours, ConsoleColor[] selectedColours) 
    {
        if (ballsCount >= level * 10)
        {
            sw.Stop();
            Console.Clear();
            ConsoleInitialSettings(field.GetLength(0), field.GetLength(1));
            PrintStringOnPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 - 8, "Scores: " + score);
            PrintStringOnPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2 - 5, "Next level-press key Enter");
            PrintStringOnPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2 - 3, "Exit - press key Escape\n");
            bool commandCorrect = false;
            while (!commandCorrect)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Environment.Exit(0);
                    commandCorrect = true;
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    sw.Reset();
                    sw.Start();
                    ballsCount = 0;
                    level++;
                    Thread.Sleep(25);
                    Console.Beep(333, 385);
                    Console.Beep(444, 385);
                    Console.Beep(666, 485);
                    Thread.Sleep(25);
                    DrawInfo(time, score, ballsCount, field.GetLength(0), field.GetLength(1));
                    Console.SetCursorPosition(0, Console.WindowHeight - field.GetLength(0));
                    GenerateField(field);
                    commandCorrect = true;
                }
                else
                {
                    PrintStringOnPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2 - 1, "Invalid key! Try again!");                    
                }
            }
        }
        if (time == "0:00")
        {
            sw.Stop();
            Console.Beep(400, 1000);
            Thread.Sleep(25);
            GameOver();
        }
    } //checks if the time is elapsed or the required balls are reached

    static void WriteScore(int score, string name)
    {
        StreamReader reader = new StreamReader(@"..\..\scores.txt");
        List<string> list = new List<string>();
        using (reader)
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                list.Add(line);
            }
        }
        string scorePlusName = score + "  " + name;   
        if (score.ToString().Length == 3)       
        {
            scorePlusName = "  " + scorePlusName;
        }
        if (score.ToString().Length == 2)
        {
            scorePlusName = "   " + scorePlusName;
        }
        if (score.ToString().Length == 1)
        {
            scorePlusName = "    " + scorePlusName;
        }           
        list.Add(scorePlusName);
        list.Sort();
        list.Reverse();
        StreamWriter writer = new StreamWriter(@"..\..\scores.txt");
        using (writer)
        {
            if (list.Count <= 10)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    writer.WriteLine(list[i]);
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine(list[i]);
                }
            }
        }
    } //reads the existing file with scores and writes the ten best scores in a file and on to the console

    static void GameOver()
    {
        Console.Beep(640, 105);
        Console.Beep(523, 105);
        Console.Beep(420, 105);
        Console.Beep(303, 105);
        Console.Beep(280, 105);;
        Console.Beep(111, 425);   
        Console.Clear();
        PrintStringOnPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 8, "Game Over");
        PrintStringOnPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 5, "Your scores are " + score);
        PrintStringOnPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 3, "Enter your name: ");
        Console.SetCursorPosition(Console.WindowWidth / 2 + 5, Console.WindowHeight / 2 - 3);
        string name = Console.ReadLine().ToLower();
        WriteScore(score, name);
        Console.Clear();
        PrintStringOnPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 - 10, "High scores\n");
        PrintStringOnPosition(0, Console.WindowHeight / 2 - 8, "Points Names\n");
        string fileName = @"..\..\scores.txt";
        ReadFile(fileName);
        PrintStringOnPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 + 4, "Press key Escape");
        PrintStringOnPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 + 5, "to exit the game");
        bool commandCorrect = false;
        while (!commandCorrect)
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            while (Console.KeyAvailable) Console.ReadKey(true);
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                Console.WriteLine(); Environment.Exit(0); commandCorrect = true;
            }
            else
            {
                PrintStringOnPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 7, "Invalid key!Try again!");
            }
        }
    } //draws an exit menu and calls WriteScore() method

    static void Play(int[,] field, ConsoleColor[] colors, ConsoleColor[] selectedColours, int[] cur, int[] sel)
    {
        if (Console.KeyAvailable)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(false);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (cur[0] < field.GetLength(0) - 1) cur[0]++;
                        Console.Beep(500, 55);
                        break;
                    case ConsoleKey.Enter:
                        SelectBall(field, colors, selectedColours, cur, sel);
                        Console.Beep(255, 20);
                        Console.Beep(155, 110);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cur[1] > 0) cur[1]--;
                        Console.Beep(500, 55);
                        break;
                    case ConsoleKey.RightArrow:
                        if (cur[1] < field.GetLength(1) - 1) cur[1]++;
                        Console.Beep(500, 55);
                        break;
                    case ConsoleKey.UpArrow:
                        if (cur[0] > 0) cur[0]--;
                        Console.Beep(500, 55);
                        break;
                    default:
                        break;
                }
            }
        }
    } //waits for the player to press key for selection or movement

    static void SelectBall(int[,] field, ConsoleColor[] colors, ConsoleColor[] selectedColours, int[] cur, int[] sel)
    {
        if (sel[1] == -1 && sel[0] == -1 && field[cur[0], cur[1]] != 1)
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
    } //selects the chosen ball

    static void ExchangeBalls(int[,] field, ConsoleColor[] colors, ConsoleColor[] selectedColours, int[] cur, int[] sel)
    {
        if ((cur[1] == sel[1] - 1 && cur[0] == sel[0]) || (cur[1] == sel[1] + 1 && cur[0] == sel[0]) || (cur[1] == sel[1] && cur[0] == sel[0] + 1) || (cur[1] == sel[1] && cur[0] == sel[0] - 1))
        {
            SwapBalls(field, cur[1], cur[0], sel[1], sel[0]);
            DrawField(field, colors, selectedColours, cur, sel);
            Thread.Sleep(500);
            if (!LinesAreAvailable(field))
            {
                SwapBalls(field, cur[1], cur[0], sel[1], sel[0]);
                Console.Beep(255, 55);
                Console.Beep(555, 225);
                DrawField(field, colors, selectedColours, cur, sel);
            }
            else
            {
                Console.Beep(355, 666);
                while (LinesAreAvailable(field))
                {
                    DeleteEqualBalls(field, colors, selectedColours, cur, sel);
                    if (!IsPossibleToPlay(field))
                    {
                        GenerateField(field);
                    }
                }
            }
            sel[0] = sel[1] = -1;
        }
    } //exchanges the current ball with the selected one

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
                            Console.Beep(755, 55);
                        }
                    }
                }
            }
        }
    } //deletes the equally colored balls by calling FindEqualBalls() method and generates new ones for the empty spaces

    static void FindEqualBalls(int[,] field, int startRow, int startCol) 
    {
        if (field[startRow, startCol] == 1)
        {
            return;
        }
        int sequence = 0;
        int value = field[startRow, startCol];
        int currentRow = startRow;
        int currentCol = startCol;
        if (startRow <= field.GetLength(0) - 3 && (value == field[currentRow + 1, currentCol] && value == field[currentRow + 2, currentCol]))      
        {
            for (currentRow = startRow; IsInside(field, currentRow, currentCol) && value == field[currentRow, currentCol]; currentRow++)
            {
                field[currentRow, currentCol] = 0;
                ballsCount++;
                sequence++;
            }
            score += (sequence * 3) * (sequence - 2);
        }
        currentRow = startRow;
        sequence = 0;
        if (startCol <= field.GetLength(1) - 3 && (value == field[currentRow, currentCol + 1] && value == field[currentRow, currentCol + 2]))     
        {
            for (currentCol = startCol; IsInside(field, currentRow, currentCol) && value == field[currentRow, currentCol]; currentCol++)
            {
                field[currentRow, currentCol] = 0;
                ballsCount++;
                sequence++;
            }
            score += (sequence * 3) * (sequence - 2);
        }
    } //finds and makes black the equally colored sequences of balls

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
    } //checks if specified row and column are within an array

    static void SwapBalls(int[,] field, int sourceX, int sourceY, int destX, int destY)
    {
        int temp = field[sourceY, sourceX];
        field[sourceY, sourceX] = field[destY, destX];
        field[destY, destX] = temp;
    } //swaps two existing balls

    static void SwapBalls(int[,] field, int sourceX, int sourceY, int newValue)
    {
        int temp = field[sourceY, sourceX];
        field[sourceY, sourceX] = newValue;
        newValue = temp;
    } //swaps a ball with a newly generated ball

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
    } //checks if there are empty spaces in the matrix

    static bool LinesAreAvailable(int[,] field)
    {
        int i;
        int j;

        for (i = 0; i < field.GetLength(0) - 2; i++)
        {
            for (j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == field[i + 1, j] && field[i, j] == field[i + 2, j] && field[i, j] != 1)
                {
                    return true;
                }
            }
        }

        for (i = 0; i < field.GetLength(0); i++)
        {
            for (j = 0; j < field.GetLength(1) - 2; j++)
            {
                if (field[i, j] == field[i, j + 1] && field[i, j] == field[i, j + 2] && field[i, j] != 1)
                {
                    return true;
                }
            }
        }
        return false;
    } //checks if there are sequences of at least three equally colored balls vertically and horizontally

    static bool IsPossibleToPlay(int[,] field)
    {                                          
        int i;
        int j;

        for (i = 0; i < field.GetLength(0) - 1; i++)
        {
            for (j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] > field[i + 1, j] || field[i, j] < field[i + 1, j])
                {
                    SwapBalls(field, j, i, j, i + 1);
                    if (LinesAreAvailable(field))
                    {
                        SwapBalls(field, j, i, j, i + 1);
                        return true;
                    }
                    SwapBalls(field, j, i, j, i + 1);
                }
            }
        }

        for (i = 0; i < field.GetLength(0); i++)
        {
            for (j = 0; j < field.GetLength(1) - 1; j++)
            {
                if (field[i, j] > field[i, j + 1] || field[i, j] < field[i, j + 1])
                {
                    SwapBalls(field, j, i, j + 1, i);
                    if (LinesAreAvailable(field))
                    {
                        SwapBalls(field, j, i, j + 1, i);
                        return true;
                    }
                    SwapBalls(field, j, i, j + 1, i);
                }
            }
        }
        return false;
    } //checks if the player has a possible move left

    static void StartSound()
    {
        while (true)
        {
            PrintStringOnPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 - 8, "Bounce Out Ball", ConsoleColor.Magenta);
            PrintStringOnPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 3, "To Start - press Enter");
            
            Console.Beep(100, 125);
            Thread.Sleep(125);
            Console.Beep(100, 125);
            Thread.Sleep(125);
            Console.Beep(150, 125);
            Thread.Sleep(125);
            Console.Beep(100, 125);
            Thread.Sleep(125);
            if (Console.KeyAvailable)
            {
                bool commandOrder = false;
                while (!commandOrder)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        commandOrder = true;                       
                    }
                } break;
            }
            Console.Beep(150, 125);
            Thread.Sleep(125);
            Console.Beep(90, 125);
            Thread.Sleep(125);
            Console.Beep(130, 125);
            Thread.Sleep(125);
            Console.Beep(70, 125);
            Thread.Sleep(125);
            if (Console.KeyAvailable)
            {
                bool commandOrder = false;
                while (!commandOrder)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        commandOrder = true;
                    }
                } break;
            }
            Console.Beep(100, 125);
            Thread.Sleep(125);
            Console.Beep(100, 125);
            Thread.Sleep(125);
            Console.Beep(150, 125);
            Thread.Sleep(125);
            Console.Beep(100, 125);
            Thread.Sleep(125);
            if (Console.KeyAvailable)
            {
                bool commandOrder = false;
                while (!commandOrder)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        commandOrder = true;
                    }
                } break;
            }
            Console.Beep(150, 125);
            Thread.Sleep(125);
            Console.Beep(90, 125);
            Thread.Sleep(125);
            Console.Beep(130, 125);
            Thread.Sleep(125);
            Console.Beep(70, 125);
            Thread.Sleep(125);
            if (Console.KeyAvailable)
            {
                bool commandOrder = false;
                while (!commandOrder)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        commandOrder = true;
                    }
                } break;
            }
            Console.Beep(100, 125);
            Thread.Sleep(125);
            Console.Beep(100, 125);
            Thread.Sleep(125);
            Console.Beep(150, 125);
            Thread.Sleep(125);
            Console.Beep(100, 125);
            Thread.Sleep(125);
            if (Console.KeyAvailable)
            {
                bool commandOrder = false;
                while (!commandOrder)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        commandOrder = true;
                    }
                } break;
            }
            Console.Beep(150, 125);
            Thread.Sleep(125);
            Console.Beep(90, 125);
            Thread.Sleep(125);
            Console.Beep(130, 125);
            Thread.Sleep(125);
            Console.Beep(70, 125);
            Thread.Sleep(125);
            if (Console.KeyAvailable)
            {
                bool commandOrder = false;
                while (!commandOrder)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        commandOrder = true;
                    }
                } break;
            }
            Console.Beep(250, 125);
            Thread.Sleep(125);
            Console.Beep(250, 125);
            Thread.Sleep(125);
            Console.Beep(200, 125);
            Thread.Sleep(125);
            Console.Beep(200, 125);
            Thread.Sleep(125);
            if (Console.KeyAvailable)
            {
                bool commandOrder = false;
                while (!commandOrder)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        commandOrder = true;
                    }
                } break;
            }
            Console.Beep(150, 125);
            Thread.Sleep(125);
            Console.Beep(150, 125);
            Thread.Sleep(125);
            Console.Beep(110, 125);
            Thread.Sleep(125);
            Console.Beep(110, 125);
            Thread.Sleep(125);
            Console.Clear();
            if (Console.KeyAvailable)
            {
                bool commandOrder = false;
                while (!commandOrder)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        commandOrder = true;
                    }
                } break;
            }
        }
    } //plays the initial sound of the game

    static int score = 0;
    static int ballsCount = 0;
    static int level = 1;
    static Stopwatch sw = new Stopwatch();
    static string time;

    static void Main()
    {   
        int playfieldWidth = 10;
        int playfieldHeight = 10;
        ConsoleColor[] colours = { ConsoleColor.Black, ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Yellow };
        ConsoleColor[] selectedColours = { ConsoleColor.Black, ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray, ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.DarkYellow };
        int[,] field = new int[playfieldHeight, playfieldWidth];
        int[] current = {field.GetLength(0) / 2, field.GetLength(1) / 2};
        int[] selected = {-1, -1};
        TimeSpan ts = new TimeSpan();
        try
        {
            StartSound();
            StartGame(playfieldHeight, playfieldWidth);
            GenerateField(field);
            while (true)
            {
                TimeSpan test = DateTime.Now.AddMinutes(2) - DateTime.Now;
                ts = test.Subtract(sw.Elapsed);
                time = String.Format("{0}:{1}", ts.Minutes.ToString("0"), ts.Seconds.ToString("00"));
                DrawField(field, colours, selectedColours, current, selected);
                DrawInfo(time, score, ballsCount, playfieldHeight, playfieldWidth);
                Play(field, colours, selectedColours, current, selected);
                CheckTimeAndBalls(field, colours, selectedColours);
            }
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine();
            Console.WriteLine("File Not Found!", exception.Message);
        }
        catch (DirectoryNotFoundException exception)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid directory!", exception.Message);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine();
            Console.WriteLine("No file path is given!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine();
            Console.WriteLine("The entered file path is not correct!");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine();
            Console.WriteLine("The entered file path is too long - 248 characters are the maximum!");
        }
        catch (NotSupportedException exception)
        {
            Console.WriteLine();
            Console.WriteLine("The given path's format is not supported!", exception.Message);
        }
        catch (System.Security.SecurityException exception)
        {
            Console.WriteLine();
            Console.WriteLine("Security error detected!", exception.Message);
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine();
            Console.WriteLine("You don't have a permission to access this file!", exception.Message);
        }
        catch (IOException exception)
        {
            Console.WriteLine();
            Console.WriteLine("An I/O error occurred while opening the file!", exception.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine();
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine();
            Console.WriteLine("Exit And Try Again!");
            Console.WriteLine("Good Bye!!!");
        }
    }
}

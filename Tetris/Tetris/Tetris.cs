using System;
using System.Linq;
using System.Threading;
using System.Text;

namespace Tetris
{
    class Tetris
    {
        class Piece
        {
            private int[] x = new int[4];
            private int[] y = new int[4];
            private char c;
            private ConsoleColor color;
            private int formIndex;
            private int rotationCount;
            public bool isFinal;

            public Piece(int offset)
            {
                Random ranGen = new Random();
                int currFormIndex = ranGen.Next(0, forms.GetLength(0));
                this.c = (char)forms[currFormIndex, 8];
                this.color = formColors[forms[currFormIndex, 9]];
                for (int i = 0; i < 4; i++)
                {
                    this.x[i] = forms[currFormIndex, i] + offset;
                    this.y[i] = forms[currFormIndex, i + 4] + 1;
                }
                this.isFinal = false;
                this.formIndex = currFormIndex;
                this.rotationCount = 0;
            }

            public void Rotate()
            {
                for (int i = 0; i < 4; i++)
                {
                    this.x[i] += rotation[this.formIndex, this.rotationCount % 4, i];
                    this.y[i] += rotation[this.formIndex, this.rotationCount % 4, i + 4];
                }
                this.rotationCount++;
            }

            public void Move(ConsoleKeyInfo pressedKey)
            {
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (isPossible('R'))
                    {
                        for (int i = 0; i < 4; i++)
                        {   
                                this.x[i]++;
                            }
                        }
                }
                else if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (isPossible('L'))
                    {
                        for (int i = 0; i < 4; i++)
                        {
                                this.x[i]--;
                            }
                        }
                }
                else if (pressedKey.Key == ConsoleKey.R)
                {
                    if(isPossible('T'))
                    {
                    Rotate();
                    }
                }
                else if(pressedKey.Key == ConsoleKey.DownArrow)
                    while (!isStopped())
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            this.y[i]++;
                        }
                    }
            }

            private bool isStopped()
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.y[i] + 1 == field.GetLength(0) - 1 || field[this.y[i] + 1, this.x[i], 0] != 0)
                    {
                        this.isFinal = true;
                        return true;
                    }
                }
                return false;
            }

            private bool isPossible(char c)
            {
                switch (c)
                {
                    case 'L':
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (this.x[i] - 1 < 1 || field[this.y[i], this.x[i] - 1, 0] != 0)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    case 'R':
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (this.x[i] + 1 > field.GetLength(1) - 2 || field[this.y[i], this.x[i] + 1, 0] != 0)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    default:
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (this.y[i] - 2 < 1 || this.y[i] + 2 > field.GetLength(0) - 1 || this.x[i] - 2 < 1 || this.x[i] + 2 > field.GetLength(1) - 1 || field[this.y[i] + rotation[this.formIndex, this.rotationCount % 4, i + 4], this.x[i] + rotation[this.formIndex, this.rotationCount % 4, i], 0] != 0)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                }
            }

            public void Move()
            {
                if (!isStopped())
                {
                    for (int i = 0; i < 4; i++)
                    {
                        this.y[i]++;
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        field[this.y[i], this.x[i],0] = 1;
                        field[this.y[i], this.x[i], 1] = (byte)Array.IndexOf(formColors,this.color);
                    }
                }
            }

            public void Draw()
            {
                for (int i = 0; i < 4; i++)
                {
                    DrawCharOnPosition(this.x[i], this.y[i], this.c, this.color);
                }
            }

            public void Clean()
            {
                for (int i = 0; i < 4; i++)
                {
                    DrawCharOnPosition(this.x[i], this.y[i], this.c, ConsoleColor.Black);
                }
            }
        }

        public static void DrawCharOnPosition(int x, int y, char c, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        public static void RemoveScrollBars(int width, int heigth)
        {
            Console.BufferHeight = Console.WindowHeight = heigth;       //clear the left scroll bar
            Console.BufferHeight = Console.WindowWidth = width;         //clear the down scroll bar
        }

        static void DrawField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                DrawCharOnPosition(0, i, '|', ConsoleColor.White);
                DrawCharOnPosition(field.GetLength(1) - 1, i, '|', ConsoleColor.White);
            }
            for (int i = 1; i < field.GetLength(1) - 1; i++)
            {
                DrawCharOnPosition(i, 0, '=', ConsoleColor.White);
                DrawCharOnPosition(i, field.GetLength(0) - 1, '=', ConsoleColor.White);
            }
            for (int i = 0; i < field.GetLength(1); i++)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    if (field[j, i, 0] != 0)
                    {
                        DrawCharOnPosition(i, j, '#', formColors[field[j, i, 1]]);
                    }
                }
            }
        }

        

        static bool GameOver()
        {
            for (int i = 0; i < field.GetLength(1); i++)
            {
                if (field[1, i, 0] != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static void DrawStringOnPosition(int x, int y, string s, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(s);
        }


        static void DrawInfo(int level, int score, int lines)
        {
            DrawStringOnPosition(field.GetLength(1) + 3, 10, "Level: " + level, ConsoleColor.White);//Draw info;
            DrawStringOnPosition(field.GetLength(1) + 3, 11, "Score: " + score, ConsoleColor.White);
            DrawStringOnPosition(field.GetLength(1) + 3, 12, "Lines: " + lines, ConsoleColor.White);
        }

        static public byte[,,] field;
        
        static public ConsoleColor[] formColors = { ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Magenta };

        static int[,] forms = { { 0, 1, 1, 2, 0, 0, 1, 1, 35, 1}, { 0, 1, 1, 2, 1, 1, 0, 0, 35, 1},
                           { 0, 1, 2, 3, 0, 0, 0, 0, 35, 2}, { 0, 1, 1, 2, 0, 1, 0, 0, 35, 3},
                           { 0, 1, 2, 2, 0, 0, 0, 1, 35, 4}, { 0, 0, 1, 2, 1, 0, 0, 0, 35, 4},
                           };

        static int[, ,] rotation = {{{ 0, -1, 0, -1, 2, 1, 0, -1 },{ 0, 1, 0, 1, -2, -1, 0, 1 },{ 0, -1, 0, -1, 2, 1, 0, -1 },{ 0, 1, 0, 1, -2, -1, 0, 1 }},
                                    {{ 1, 0, -1, -2, 1, 0, 1, 0 },{ -1, 0, 1, 2, -1, 0, -1, 0 },{ 1, 0, -1, -2, 1, 0, 1, 0},{ -1, 0, 1, 2, -1, 0, -1, 0}},
                                    {{ 2, 1, 0, -1, -2, -1, 0, 1 },{ -2, -1, 0, 1, 2, 1, 0, -1},{ 2, 1, 0, -1, -2, -1, 0, 1},{ -2, -1, 0, 1, 2, 1, 0, -1}},
                                    {{ 1, -1, 0, -1, -1, -1, 0, 1 },{ 1, 1, 0, -1, 1, -1, 0, -1},{ -1, 1, 0, 1, 1, 1, 0, -1},{ -1, -1, 0, 1, -1, 1, 0, 1}}, 
                                    {{ 2, 1, 0, -1, -2, -1, 0, -1},{ 2, 1, 0, 1, 2, 1, 0, -1},{-2, -1, 0, 1, 2, 1, 0, 1},{ -2, -1, 0, -1, -2, -1, 0, 1}},
                                    {{ -1, 0, -1, -2, -1, 0, 1, 2 },{ 1, 0, -1, -2, -1, 0, -1, -2 },{ 1, 0, 1, 2, 1, 0, -1, -2},{ -1, 0, 1, 2, 1, 0, 1, 2}}};

        static void Main()
        {
            int level = 0;
            int linesCount = 0;
            int score = 0;
            int playfieldWidth = 16;
            int playfieldHeigth = 30;
            field = new byte[playfieldHeigth, playfieldWidth, 2];
            RemoveScrollBars(playfieldWidth * 2, playfieldHeigth);        //Remove the scroll bars
            Console.Title = "Tetris";
            Piece currentPiece = new Piece(playfieldWidth / 2 - 2);       //Create the first piece
            while (true)
            {
                Console.Clear();                //Clear the field
                DrawField();                    //Redraw the field;
                currentPiece.Draw();            //Draw the piece
                while (Console.KeyAvailable)    //Move if possible the piece left/right or rotate if a proper key is pressed
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    currentPiece.Clean();
                    currentPiece.Move(pressedKey);
                    currentPiece.Draw();
                };
                currentPiece.Move();            //Check if possible and move down or stop moving
                if (currentPiece.isFinal)       //If stop moving check lines and score
                {
                    score += 4;
                    for ( int i = 0; i < field.GetLength(0); i++)
                    {
                        int line = 1;
                        for (int j = 1; j < field.GetLength(1) - 1; j++)
                        {
                            line *= field[i, j, 0];
                        }
                        if (line != 0)
                        {
                            linesCount++;
                            level = level < 5 ? linesCount / 20 : 5;
                            score += 40;
                            for (int c = 0; c < field.GetLength(1); c++)
                            {
                                for (int r = i; r > 0; r--)
                                {
                                    field[r, c, 0] = field[r - 1, c, 0];
                                    field[r, c, 1] = field[r - 1, c, 1];
                                }
                                field[0, c, 0] = 0;
                                field[0, c, 1] = 0;
                            }
                        }
                    }
                    currentPiece = new Piece(playfieldWidth / 2 - 2);
                }
                DrawInfo(level, score, linesCount); //Draw info
                if (GameOver())                 //Check if game over
                {
                    DrawStringOnPosition(field.GetLength(1) - 6, field.GetLength(0) / 2, "!!!GAME OVER!!!", ConsoleColor.Red);
                    Console.WriteLine();
                    break;
                }
                Console.Beep();                               //Play sound
                Thread.Sleep(600 - 100 * level);              //Slow the program
            }
        }
    }
}

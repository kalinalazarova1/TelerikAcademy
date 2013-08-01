// Implement the "Falling Rocks" game in the text console.
// A small dwarf stays at the bottom of the screen and can
//move left and right (by the arrows keys). A number of
//rocks of different sizes and forms constantly fall down
//and you need to avoid a crash.
//Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;,
// - distributed with appropriate density. The dwarf is (O).
// Ensure a constant game speed by Thread.Sleep(150).
// Implement collision detection and scoring system.

using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    struct GameObject
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;
    }

    public static void DrawObjectOnPosition (int x, int y, char c, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    public static void DrawStringOnPosition(int x, int y, string s, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(s);
    }

    static void Main()                      //Game speed depends on the level, a heart is a bonus which gives an extra life
    {
        int playfield = 18;                  //Define the playfield;
        int lifes = 3;
        int score = 0;
        int level = 0;
        char[] shapes = {'!','@','#','$','%','^','&','*','+','.',';'};
        ConsoleColor[] colors = {ConsoleColor.Gray, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.Yellow};
        Random randomGen = new Random();
        Console.BufferHeight = Console.WindowHeight = 20;    //clear the left scroll bar
        Console.BufferHeight = Console.WindowWidth = 60;     //clear the down scroll bar
        Console.Title = "Falling Rocks";
        GameObject dwarf = new GameObject();
        dwarf.x = playfield / 2 + 1;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.c = 'O';
        dwarf.color = ConsoleColor.Green;
        List<GameObject> rocks = new List<GameObject>();
        while (true)
        {
            bool detectCollision = false;
            bool getBonus = false;
            int chance = randomGen.Next(0, 100);
            int rockX = randomGen.Next(0, playfield - 1);
            char rockChar;
            if (chance < 3)
            {
                rockChar = (char)3;
            }
            else
            {
                rockChar = shapes[randomGen.Next(0, shapes.Length)];
            }
            ConsoleColor rockCol = colors[randomGen.Next(0, colors.Length)];
            for (int i = 1; i <= randomGen.Next(1, 4); i++)
            {
                GameObject newRock = new GameObject();
                newRock.y = 0;
                
                if (newRock.x >= playfield) newRock.x = playfield - 1;
                newRock.c = rockChar;
                if (newRock.c == (char)3)
                {
                    newRock.color = ConsoleColor.Red;
                    newRock.x = rockX;
                }
                else
                {
                    newRock.color = rockCol;
                    newRock.x = rockX + i - 1;
                }
                rocks.Add(newRock);
            }
            while (Console.KeyAvailable)            //Move the dwarf if arrow key is pressed;
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if(pressedKey.Key == ConsoleKey.RightArrow)
                    if ((dwarf.x + 2) < playfield)
                    {
                        dwarf.x++;
                    }
                if(pressedKey.Key == ConsoleKey.LeftArrow)         
                    if ((dwarf.x - 2) >= 0)
                    {
                        dwarf.x--;
                    }
            }
            List<GameObject> currentRocks = new List<GameObject>();
            for (int i = 0; i < rocks.Count; i++)                  //Move the rocks;
            {
                GameObject oldRock = rocks[i];
                GameObject currentRock = new GameObject();
                currentRock.x = oldRock.x;
                currentRock.y = oldRock.y + 1;
                currentRock.c = oldRock.c;
                currentRock.color = oldRock.color;
                if (currentRock.y < Console.WindowHeight)
                {
                    currentRocks.Add(currentRock);
                }
                else
                {
                    score++;
                    if(level < 5)   level = score / 50;
                }
            }
            rocks = currentRocks;
            foreach (GameObject rock in rocks)                          //Check for collision;
            {
                if (((rock.x == dwarf.x - 1)||
                    (rock.x == dwarf.x) || 
                    (rock.x == dwarf.x + 1)) && (rock.y == dwarf.y))
                {
                    if (rock.c == (char)3)
                    {
                        getBonus = true;
                    }
                    else
                    {
                        detectCollision = true;
                    }
                    
                }
            }            
            Console.Clear();                                            //Clear the console;
            if (getBonus)
            {
                lifes++;
            }
            if (detectCollision)                                        //Redraw the field;
            {
                lifes--;
                if (lifes <= 0)
                {
                    DrawStringOnPosition(playfield + 6, 12, "Lives: " + lifes, ConsoleColor.White);
                    DrawStringOnPosition(playfield + 6, 11, "Score: " + score, ConsoleColor.White);
                    DrawObjectOnPosition(dwarf.x, dwarf.y, 'X', ConsoleColor.Red);
                    DrawStringOnPosition(playfield + 1, 15, "GAME OVER!!!", ConsoleColor.Red);
                    DrawStringOnPosition(playfield + 1, 16, "Press [enter] to exit.", ConsoleColor.Red);
                    Console.Beep(500, 200);
                    Console.Beep(600, 200);
                    Console.Beep(700, 800);
                    Console.ReadLine();
                    return;
                }
                DrawObjectOnPosition(dwarf.x, dwarf.y, 'X', ConsoleColor.Red);
                rocks.Clear();
                Console.Beep(500, 200);
                Console.Beep(600, 200);
                Console.Beep(700, 800);
            }
            else
            {
                DrawObjectOnPosition(dwarf.x - 1, dwarf.y, '(', dwarf.color);
                DrawObjectOnPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
                DrawObjectOnPosition(dwarf.x + 1, dwarf.y, ')', dwarf.color);
            }
            foreach (GameObject rock in rocks)
            {
                DrawObjectOnPosition(rock.x, rock.y, rock.c, rock.color);
            }
            for (int i = 0; i < Console.WindowHeight; i++)
            DrawObjectOnPosition(playfield, i,'|', ConsoleColor.White);
            DrawStringOnPosition(playfield + 6, 10, "Level: " + level, ConsoleColor.White);//Draw info;
            DrawStringOnPosition(playfield + 6, 11, "Score: " + score, ConsoleColor.White);
            DrawStringOnPosition(playfield + 6, 12, "Lives: " + lifes, ConsoleColor.White);
            Console.Beep();
            Thread.Sleep(600 - level*100);                                              //Slow the program;
        }
    }
}

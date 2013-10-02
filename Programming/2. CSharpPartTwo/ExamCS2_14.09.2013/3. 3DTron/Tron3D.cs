using System;

class Tron3D
{
    static bool IsInside(bool[,] arr, int x, int y)
    {
        if (x >= 0 && x < arr.GetLength(0)) return true;
        else return false;
    }

    static int Play(int player, bool[,] forbidden, int[,] currPlace, bool[] isLoser, string movement, int movePos)
    {
        int i = movePos;
        while (i < movement.Length && movement[i] != 'M')
        {
            if (movement[i] == 'L')
            {
                if (currPlace[player, 2] == 0)
                {
                    currPlace[player, 2] = currPlace[player, 3];
                    currPlace[player, 3] = 0;
                }
                else
                {
                    currPlace[player, 3] = -currPlace[player, 2];
                    currPlace[player, 2] = 0;
                }
            }
            else
            {
                if (currPlace[player, 2] == 0)
                {
                    currPlace[player, 2] = -currPlace[player, 3];
                    currPlace[player, 3] = 0;
                }
                else
                {
                    currPlace[player, 3] = currPlace[player, 2];
                    currPlace[player, 2] = 0;
                }
            }
            i++;
        }
        if (currPlace[player, 1] + currPlace[player, 3] == forbidden.GetLength(1))
        {
            currPlace[player, 1] = 0;
        }
        else if (currPlace[player, 1] + currPlace[player, 3] == -1)
        {
            currPlace[player, 1] = forbidden.GetLength(1) - 1;
        }
        else if (IsInside(forbidden, currPlace[player, 0] + currPlace[player, 2], currPlace[player, 1] + currPlace[player, 3])
            && !forbidden[currPlace[player, 0] + currPlace[player, 2], currPlace[player, 1] + currPlace[player, 3]])
        {
            currPlace[player, 0] += currPlace[player, 2];
            currPlace[player, 1] += currPlace[player, 3];
        }
        else if (!IsInside(forbidden, currPlace[player, 0] + currPlace[player, 2], currPlace[player, 1] + currPlace[player, 3]))
        {
            isLoser[player] = true;
        }
        else
        {
            currPlace[player, 0] += currPlace[player, 2];
            currPlace[player, 1] += currPlace[player, 3];
            isLoser[player] = true;
        }
        return ++i;
    }

    static void Main()
    {
        bool[] isLoser = new bool[2];
        string[] input = Console.ReadLine().Split(' ');
        int x = int.Parse(input[0]);
        int y = int.Parse(input[1]);
        int z = int.Parse(input[2]);
        bool[,] forbidden = new bool[x + 1, 2 * (y + z)]; 
        string[] play = new string[2];
        play[0] = Console.ReadLine();   //movement of the first player;
        play[1] = Console.ReadLine();   //movement of the second player;
        int[,] currPlace = new int[2, 4];//initaial coordinates and moving direction;
        currPlace[0, 0] = x / 2;        //x coordinate for the first player;
        currPlace[0, 1] = y / 2;        //y coordinate for the first player;
        currPlace[0, 2] = 0;            //direction 0 means no change in x while moving for the first player;
        currPlace[0, 3] = 1;            //direction 1 means change with +1 in y while moving for the first player;
        currPlace[1, 0] = x / 2;        //same for the second player
        currPlace[1, 1] = y + z + y / 2;
        currPlace[1, 2] = 0;            
        currPlace[1, 3] = -1;
        forbidden[currPlace[0, 0], currPlace[0, 1]] = true;
        forbidden[currPlace[1, 0], currPlace[1, 1]] = true;
        //Console.WriteLine("{0} {1}", currPlace[0, 0], currPlace[0, 1]);
        //Console.WriteLine("{0} {1}", currPlace[1, 0], currPlace[1, 1]);
        int i = 0;
        for (int j = 0; !isLoser[0] && !isLoser[1];)
        {
            i = Play(0, forbidden, currPlace, isLoser, play[0], i);
            //Console.WriteLine("{0} {1}", currPlace[0, 0], currPlace[0, 1]);
            j = Play(1, forbidden, currPlace, isLoser, play[1], j);
            //Console.WriteLine("{0} {1}", currPlace[1, 0], currPlace[1, 1]);
            if(currPlace[0, 0] == currPlace[1, 0] && currPlace[0, 1] == currPlace[1, 1])
            {
                isLoser[0] = true;
                isLoser[1] = true;
            }
            forbidden[currPlace[0, 0], currPlace[0, 1]] = true;
            forbidden[currPlace[1, 0], currPlace[1, 1]] = true;
        }
        if (isLoser[0] && isLoser[1]) Console.WriteLine("DRAW");
        else if (!isLoser[0] && isLoser[1]) Console.WriteLine("RED");
        else if (isLoser[0] && !isLoser[1]) Console.WriteLine("BLUE");
        Console.WriteLine(Math.Abs(currPlace[0, 0] - x / 2) + Math.Abs(currPlace[0, 1] - y / 2));
    }
}

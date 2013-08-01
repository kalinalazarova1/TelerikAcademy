using System;

class Problem_10_11
{
    static char[,] lab = new char[100, 100];

    static void InitalizeLab()
    {
        for (int r = 0; r < 100; r++)
            for (int c = 0; c < 100; c++) lab[r, c] = ' ';
    }

    static void FindRoute(int startRow, int startCol, int endRow, int endCol)
    {
        if (startCol >= lab.GetLength(1) || startRow >= lab.GetLength(0) || startCol < 0 || startRow < 0)
        {
            return;
        }
        if (startRow == endRow && startCol == endCol)
        {
            Console.WriteLine("There is a way!");
            return;
        }
        if (lab[startRow, startCol] == ' ')
        {
            lab[startRow, startCol] = 'S';
            FindRoute(startRow, startCol - 1, endRow, endCol);
            FindRoute(startRow - 1, startCol, endRow, endCol);
            FindRoute(startRow, startCol + 1, endRow, endCol);
            FindRoute(startRow + 1, startCol, endRow, endCol);
        }
    }

    static void Main()
    {
        int startRow, startCol, endRow, endCol;
        InitalizeLab();
        Console.WriteLine("Please input the start row:");
        startRow = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input the start column:");
        startCol = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input the end row:");
        endRow = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input the end column:");
        endCol = Int32.Parse(Console.ReadLine());
        FindRoute(startRow, startCol, endRow, endCol);
    }
}


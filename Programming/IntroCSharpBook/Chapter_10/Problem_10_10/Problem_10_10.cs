using System;

class Problem_10_10
{
    static char[,] lab =
{
{' ', ' ', ' ', '*', ' ', ' ', ' '},
{'*', '*', ' ', '*', ' ', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', ' '},
{' ', '*', '*', '*', '*', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', ' '},
};
    static char[] route = new char[lab.GetLength(0) * lab.GetLength(1)];
    static int index = 0;

    static void FindRoute(int startRow, int startCol, int endRow, int endCol, char dir)
    {
        if (startCol >= lab.GetLength(1) || startRow >= lab.GetLength(0) || startCol < 0 || startRow < 0)
        {
            return;
        }
        route[index++] = dir;
        if (startRow == endRow && startCol == endCol)
        {
            Console.WriteLine("Found the route!: ");
            PrintRoute(1, --index);
            return;
        }
        if (lab[startRow, startCol] == ' ')
        {
            lab[startRow, startCol] = 'S';
            FindRoute(startRow, startCol - 1, endRow, endCol, 'L');
            FindRoute(startRow - 1, startCol, endRow, endCol, 'U');
            FindRoute(startRow, startCol + 1, endRow, endCol, 'R');
            FindRoute(startRow + 1, startCol, endRow, endCol, 'D');
            lab[startRow, startCol] = ' ';
        }
        index--;
    }

    static void PrintRoute(int startIndex, int endIndex)
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(route[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int startRow, startCol, endRow, endCol;
        Console.WriteLine("Please input the start row:");
        startRow = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input the start column:");
        startCol = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input the end row:");
        endRow = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input the end column:");
        endCol = Int32.Parse(Console.ReadLine());
        FindRoute(startRow, startCol, endRow, endCol, 's');
    }
}

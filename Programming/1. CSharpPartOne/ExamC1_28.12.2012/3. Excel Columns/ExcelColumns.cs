using System;

class ExcelColumns
{
    static void Main()
    {
        ulong columnIndex = 0;
        int idLength = int.Parse(Console.ReadLine());
        char columnIdentifier;
        for (int i = 0; i < idLength; i++)
        {
            columnIdentifier = char.Parse(Console.ReadLine());
            columnIndex = columnIndex + (ulong)((columnIdentifier - 'A' + 1) * Math.Pow(26, idLength - 1 - i));
        }
        Console.WriteLine(columnIndex);
    }
}

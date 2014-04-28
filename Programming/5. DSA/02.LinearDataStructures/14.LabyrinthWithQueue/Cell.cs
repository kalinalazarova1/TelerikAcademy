using System;

public class Cell
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Distance { get; set; }

    public Cell(int r, int c, int distance)
    {
        this.Row = r;
        this.Col = c;
        this.Distance = distance;
    }
}

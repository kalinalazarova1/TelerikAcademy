// 2.Refactor the following if statements:

using System;
using System.Collections.Generic;
using _01.Cooking;

public class Program
{
    public static void Main(string[] args)
    {
        // First Task:
        Potato potato = new Potato();

        // ... 
        if (potato == null)
        {
            throw new ArgumentNullException();
        }

        var me = new Chef("Ivan");
        var ingredients = new List<Vegetable>();
        ingredients.Add(potato);
        if (potato.IsPeeled && !potato.IsRotten)
        {
            me.CookVegitables(ingredients, new Bowl());
        }

        // Second Task:
        const int MIN_X = -100;
        const int MAX_X = 100;
        const int MIN_Y = -50;
        const int MAX_Y = 50;
        int x = 0;
        int y = 0;
        bool shouldVisitCell = true;
        bool inRangeX = MIN_X <= x && x <= MAX_X;
        bool inRangeY = MIN_Y <= y && y <= MAX_Y;

        if (inRangeX && inRangeY && shouldVisitCell)
        {
            VisitCell(x, y);
        }
    }

    public static void VisitCell(int x, int y)
    {
        Console.WriteLine("Cell ({0}, {1}) is visited!", x, y);
    }
}

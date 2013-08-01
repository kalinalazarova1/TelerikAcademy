using System;

class FighterAttack
{
    static bool IsHit (int x, int y, int left, int up, int right, int down)
    {
        if ((x >= left && x <= right) && (y <= up && y >= down))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        ushort damage = 0;
        int fieldX1 = int.Parse(Console.ReadLine());
        int fieldY1 = int.Parse(Console.ReadLine());
        int fieldX2 = int.Parse(Console.ReadLine());
        int fieldY2 = int.Parse(Console.ReadLine());
        int fieldLeftUpX = Math.Min(fieldX1, fieldX2);
        int fieldRightDownX = Math.Max(fieldX1, fieldX2);
        int fieldLeftUpY = Math.Max(fieldY1, fieldY2);
        int fieldRightDownY = Math.Min(fieldY1, fieldY2);
        int fighterX = int.Parse(Console.ReadLine());
        int fighterY = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        //fire
        fighterX = fighterX + distance;
        //check for hit
        if (IsHit(fighterX, fighterY, fieldLeftUpX, fieldLeftUpY, fieldRightDownX, fieldRightDownY))
        {
            damage += 100;
        }
        if (IsHit(fighterX + 1, fighterY, fieldLeftUpX, fieldLeftUpY, fieldRightDownX, fieldRightDownY))
        {
            damage += 75;
        }
        if (IsHit(fighterX, fighterY + 1, fieldLeftUpX, fieldLeftUpY, fieldRightDownX, fieldRightDownY))
        {
            damage += 50;
        }
        if (IsHit(fighterX, fighterY - 1, fieldLeftUpX, fieldLeftUpY, fieldRightDownX, fieldRightDownY))
        {
            damage += 50;
        }
        //print damage
        Console.WriteLine("{0}%", damage);
    }
}

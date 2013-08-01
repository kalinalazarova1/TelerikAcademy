using System;

class ShipDamage
{
    static void Main()
    {
        ushort damage = 0;
        int shipX1 = int.Parse(Console.ReadLine());
        int shipY1 = int.Parse(Console.ReadLine());
        int shipX2 = int.Parse(Console.ReadLine());
        int shipY2 = int.Parse(Console.ReadLine());
        int shipUpLeftX = Math.Min(shipX1, shipX2);
        int shipDownRightX = Math.Max(shipX1, shipX2);
        int shipUpLeftY = Math.Max(shipY1, shipY2);
        int shipDownRightY = Math.Min(shipY1, shipY2);
        int horizon = int.Parse(Console.ReadLine());
        int cat1X = int.Parse(Console.ReadLine());
        int cat1Y = int.Parse(Console.ReadLine());
        int cat2X = int.Parse(Console.ReadLine());
        int cat2Y = int.Parse(Console.ReadLine());
        int cat3X = int.Parse(Console.ReadLine());
        int cat3Y = int.Parse(Console.ReadLine());
        //fire
        if (horizon > cat1Y)
        {
            cat1Y = cat1Y + Math.Abs(cat1Y - horizon) * 2;
        }
        else
        {
            cat1Y = cat1Y - Math.Abs(cat1Y - horizon) * 2;
        }
        if (horizon > cat2Y)
        {
            cat2Y = cat2Y + Math.Abs(cat2Y - horizon) * 2;
        }
        else
        {
            cat2Y = cat2Y - Math.Abs(cat2Y - horizon) * 2;
        }
        if (horizon > cat3Y)
        {
            cat3Y = cat3Y + Math.Abs(cat3Y - horizon) * 2;
        }
        else
        {
            cat3Y = cat3Y - Math.Abs(cat3Y - horizon) * 2;
        }
        //check hit catapult 1
        if ((cat1X >= shipUpLeftX && cat1X <= shipDownRightX) && (cat1Y <= shipUpLeftY && cat1Y >= shipDownRightY))
        {
            damage += 100;
            if (cat1X == shipUpLeftX || cat1X == shipDownRightX || cat1Y == shipUpLeftY || cat1Y == shipDownRightY)
            {
                damage -= 50;
                if ((cat1X == shipUpLeftX && cat1Y == shipDownRightY) || (cat1X == shipDownRightX && cat1Y == shipUpLeftY))
                    damage -= 25;
                else if ((cat1X == shipUpLeftX && cat1Y == shipUpLeftY) || (cat1X == shipDownRightX && cat1Y == shipDownRightY))
                    damage -= 25;
            }
        }
        //check hit catapult 2
        if ((cat2X >= shipUpLeftX && cat2X <= shipDownRightX) && (cat2Y <= shipUpLeftY && cat2Y >= shipDownRightY))
        {
            damage += 100;
            if (cat2X == shipUpLeftX || cat2X == shipDownRightX || cat2Y == shipUpLeftY || cat2Y == shipDownRightY)
            {
                damage -= 50;
                if ((cat2X == shipUpLeftX && cat2Y == shipDownRightY) || (cat2X == shipDownRightX && cat2Y == shipUpLeftY))
                    damage -= 25;
                else if ((cat2X == shipUpLeftX && cat2Y == shipUpLeftY) || (cat2X == shipDownRightX && cat2Y == shipDownRightY))
                    damage -= 25;
            }
        }
        //check hit catapult 3
        if ((cat3X >= shipUpLeftX && cat3X <= shipDownRightX) && (cat3Y <= shipUpLeftY && cat3Y >= shipDownRightY))
        {
            damage += 100;
            if (cat3X == shipUpLeftX || cat3X == shipDownRightX || cat3Y == shipUpLeftY || cat3Y == shipDownRightY)
            {
                damage -= 50;
                if ((cat3X == shipUpLeftX && cat3Y == shipDownRightY) || (cat3X == shipDownRightX && cat3Y == shipUpLeftY))
                    damage -= 25;
                else if ((cat3X == shipUpLeftX && cat3Y == shipUpLeftY) || (cat3X == shipDownRightX && cat3Y == shipDownRightY))
                    damage -= 25;
            }
        }
        //print damage
        Console.WriteLine("{0}%",damage);
    }
}

using System;

class Program
{
    static void Main()
    {
        ushort[] vegetableAmounts = new ushort[6];
        short[] vegetableArea = new short[6];
        short totalArea = 0;
        decimal totalCost = 0.0m;
        decimal[] prices = {0.5m, 0.4m, 0.25m, 0.6m, 0.3m, 0.4m};
        for (int i = 0; i < 5; i++)
        {
            vegetableAmounts[i] = ushort.Parse(Console.ReadLine());
            vegetableArea[i] = short.Parse(Console.ReadLine());
        }
        vegetableAmounts[5] = ushort.Parse(Console.ReadLine());
        for (byte i = 0; i < vegetableAmounts.Length - 1; i++)
        {
            totalArea += vegetableArea[i];
            totalCost += vegetableAmounts[i] * prices[i]; 
        }
        vegetableArea[5] = (short)(250 - totalArea);
        totalCost += (decimal)(vegetableAmounts[5] * prices[5]);
        Console.WriteLine("Total costs: {0}", totalCost);
        if (totalArea < 250)
        {
            Console.WriteLine("Beans area: {0}", 250 - totalArea);
        }
        else if (totalArea == 250)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }
    }
}

using System;

class CoffeeVendingMachine
{
    static void Main()
    {
        decimal traySum = 0;
        decimal[] coins = { 0.05m, 0.10m, 0.20m, 0.50m, 1.00m };
        for (byte i = 0; i < 5; i++)
        {
            ushort coinAmount= ushort.Parse(Console.ReadLine());
            traySum += coinAmount * coins[i];
        }
        decimal inputSum = decimal.Parse(Console.ReadLine());
        decimal drinkPrice = decimal.Parse(Console.ReadLine());

        if (inputSum < drinkPrice)
        {
            Console.WriteLine("More {0}", drinkPrice - inputSum);
        }
        else if (traySum < (inputSum - drinkPrice))
        {
            Console.WriteLine("No {0}", inputSum - drinkPrice - traySum);
        }
        else
        {
            Console.WriteLine("Yes {0}", traySum - inputSum + drinkPrice);
        }
    }
}

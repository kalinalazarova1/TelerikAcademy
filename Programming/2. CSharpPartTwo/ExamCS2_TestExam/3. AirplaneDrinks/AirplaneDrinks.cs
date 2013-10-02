using System;

class AirplaneDrinks
{
    static long GetMovementTime(bool[] isTea, int teaNumber)
    {
        long distance = 0;
        int teaCounter = 0;
        int coffeeCounter = 0;
        for (int i = isTea.Length - 1; i >= 1; i--)
        {
            if (isTea[i])
            {
                teaCounter++;
                if (teaCounter % 7 == 1)
                {
                    distance += (long)i * 2;
                }
            }
            else
            {
                coffeeCounter++;
                if (coffeeCounter % 7 == 1)
                {
                    distance += (long)i * 2;
                }
            }
        }
        return distance;
    }

    static void Main()
    {
        long time = 0;
        int n = int.Parse(Console.ReadLine());
        int teaNumber = int.Parse(Console.ReadLine());
        bool[] isTea = new bool[n + 1];
        for (int i = 0; i < teaNumber; i++)
        {
            isTea[int.Parse(Console.ReadLine())] = true;
        }
        time += (long)(n * 4);
        time += (long)(47 * (teaNumber / 7 + (teaNumber % 7 != 0 ? 1 : 0)));
        time += (long)(47 * ((n - teaNumber) / 7 + ((n - teaNumber) % 7 != 0 ? 1 : 0)));
        time += GetMovementTime(isTea, teaNumber);
        Console.WriteLine(time);
    }
}

using System;

class Problem_5
{
    static void Main()
    {
        Console.WriteLine("Моля въведете последователно двата катета:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Хипотенузата е: {0: 0.000}", Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)));
    }
}

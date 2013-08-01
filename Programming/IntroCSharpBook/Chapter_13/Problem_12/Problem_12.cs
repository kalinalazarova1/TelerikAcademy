using System;
using System.Text;

class Problem_12
{
    static void Main()
    {
        double input = double.Parse(Console.ReadLine());
        Console.WriteLine("{0,15:d}", (int)input);
        Console.WriteLine("{0,15:x}",(int)input);
        Console.WriteLine("{0,15:e8}", input);
        Console.WriteLine("{0,15:p2}", input);
        Console.WriteLine("{0,15:c2}", input);
    }
}

using System;

class FirstTenNumbers   //Print the first ten numbers of the sequence: 2, -3, 4, -5, 6, -7...
{
    static void Main()
    {
        for (int i = 2; i < 12; i++)
        {
            Console.Write("{0}, ", i * Math.Pow(-1, i)); 
        }
    }
}

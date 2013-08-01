//Declare a boolean variable IsFemale and assign it with a proper value according to your gender

using System;

class DeclareBoolIsFemale
{
    static void Main()
    {
        bool IsFemale;
        Console.WriteLine("Please input your gender(m/f):");
        IsFemale = (Char.Parse(Console.ReadLine()) == 'f');
        if (IsFemale)
            Console.WriteLine("You are female.");
        else
            Console.WriteLine("You are not female.");
    }
}

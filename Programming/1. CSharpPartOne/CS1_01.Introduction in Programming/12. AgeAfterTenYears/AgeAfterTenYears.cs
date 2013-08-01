using System;

class AgeAfterTenYears  //Reads your age from the console and prints how old you will be after ten years
{
    static void Main()
    {
        Console.WriteLine("Please input your current age:");
        int age = Int32.Parse(Console.ReadLine());
        Console.WriteLine("On {0} you will be {1} years old.", DateTime.Now.AddYears(10), age + 10);
    }
}

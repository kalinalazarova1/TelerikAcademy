using System;

class Problem_7
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (input.Length > 20)
        {
            string trimmedInput = input.Remove(20);
            Console.WriteLine(trimmedInput.PadRight(20, '*'));
        }
        else
        {
            Console.WriteLine(input.PadRight(20, '*'));
        }
    }
}

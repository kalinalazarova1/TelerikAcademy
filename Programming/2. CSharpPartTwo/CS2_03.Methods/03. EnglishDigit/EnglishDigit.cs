//3. Write a method that returns the last digit of a given integer as an English word.
//Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

using System;

class EnglishDigit
{
    static string GetLastDigit(int num)
    {
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return digits[num % 10];
    }

    static void Main()
    {
        
        Console.WriteLine("Please input an integer number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("The last digit is: {0}", GetLastDigit(number));
    }
}

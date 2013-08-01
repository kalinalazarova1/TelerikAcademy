//Write a program that applies bonus scores to given scores in the range [1; 9]
//If the digit is between 1 and 3 the program multiplies it by 10, if it is between 4 and 6 
//multiplies it by 100; if its between 7 and 9 multiplies it with 1000. If its zero or if the value
//is not a digit the program must report an error.

using System;

class AddBonus
{
    static void Main()
    {
        string userScore;
        Console.WriteLine("Please enter your score in the range [1;9]:");
        userScore = Console.ReadLine();
        switch (userScore)
        {
            case "1":
            case "2":
            case "3":
                Console.WriteLine("Your new score is: {0}", Int32.Parse(userScore) * 10);
                break;
            case "4":
            case "5":
            case "6":
                Console.WriteLine("Your new score is: {0}", Int32.Parse(userScore) * 100);
                break;
            case "7":
            case "8":
            case "9":
                Console.WriteLine("Your new score is: {0}", Int32.Parse(userScore) * 1000);
                break;
            default:
                Console.WriteLine("Invalid score!");
                break;
        }
    }
}

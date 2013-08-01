//Write a program that depending on the user's choice inputs int, double or string variable.
//If the variable is integer or double increases it with 1. If the variable is string appends "*" at its end.
//The program must show the value of that variable as console output. Use switch statement.

using System;

class UserChoiceVarInput
{
    static void Main()
    {
        byte userChoice;
        int inputInt;
        double inputDouble;
        string inputString;
        bool isValid;
        do
        {
            Console.WriteLine("Please enter your choice 1(for int), 2(for double), 3(for string):");
            isValid = byte.TryParse(Console.ReadLine(), out userChoice);
        }
        while (!isValid);  
        switch (userChoice)
        {
            case 1: 
                do
                {
                    Console.WriteLine("Please input the value of the variable:");
                    isValid = Int32.TryParse(Console.ReadLine(), out inputInt);     
                }
                while(!isValid);
                Console.Write("New value: {0}", inputInt + 1);
                break;
            case 2:
                do
                {
                    Console.WriteLine("Please input the value of the variable:");
                    isValid = double.TryParse(Console.ReadLine(), out inputDouble);
                }
                while (!isValid);
                Console.Write("New value: {0}", inputDouble + 1);
                break;
            case 3:
                Console.WriteLine("Please input the value of the variable:");
                inputString = Console.ReadLine(); 
                Console.Write("New value: {0}", (string)inputString + "*");
                break;
            default:
                Console.WriteLine("Invalid data entry!");
                break;
        }
    }
}

//Write an if statement that examines two integer variables and exchanges their values
//if the first one is greater than the second one.

using System;

class ExchangeValuesInt
{
    static void Main()
    {
        int firstNum, secondNum;
        bool isValid;
        do
        {
            Console.WriteLine("Please enter the first integer number:");
            isValid = Int32.TryParse(Console.ReadLine(), out firstNum);
        }
        while (!isValid);
        do
        {
            Console.WriteLine("Please enter the second integer number:");
            isValid = Int32.TryParse(Console.ReadLine(), out secondNum);
        }
        while (!isValid);
        if (firstNum > secondNum)
        {
            firstNum ^= secondNum;
            secondNum ^= firstNum;
            firstNum ^= secondNum;
        }
        Console.WriteLine("{0} is less than {1}.", firstNum, secondNum);
    }
}

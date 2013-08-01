using System;
using System.Text;

class Program
{
    static void Main()
    {
        bool IsCorrectBracket = true;
        ushort leftBracket = 0;
        ushort rightBracket = 0;
        Console.WriteLine("Please input an arithmetic expression:");
        string expression = Console.ReadLine();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                leftBracket++;
            }
            else if (expression[i] == ')')
            {
                rightBracket++;
                if (leftBracket < rightBracket)
                {
                    IsCorrectBracket = false;
                    break;
                }
            }
        }
        if (leftBracket > rightBracket)
        {
            IsCorrectBracket = false;
        }
        if (IsCorrectBracket)
        {
            Console.WriteLine("Correct bracket placement!");
        }
        else
        {
            Console.WriteLine("Incorrect bracket placement!");
        }
    }
}

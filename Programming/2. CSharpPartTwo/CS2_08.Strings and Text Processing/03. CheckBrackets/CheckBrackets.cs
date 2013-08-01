//2. Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;

class CheckBrackets
{
    static bool areCorrectBrackets(string expression)
    {
        int pairedBrackets = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                pairedBrackets++;
            }
            else if (expression[i] == ')')
            {
                pairedBrackets--;
            }
            if (pairedBrackets < 0)
            {
                return false;
            }
        }
        if (pairedBrackets != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static void Main()
    {
        string expression = "((a+b)/5-d)";
        if (areCorrectBrackets(expression))
        {
            Console.WriteLine("Correct brackets!");
        }
        else
        {
            Console.WriteLine("Incorrect brackets!");
        }
    }
}

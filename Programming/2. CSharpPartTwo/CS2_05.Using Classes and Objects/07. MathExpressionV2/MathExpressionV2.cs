// 7.* Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
//Real numbers, e.g. 5, 18.33, 3.14159, 12.6
//Arithmetic operators: +, -, *, / (standard priorities)
//Mathematical functions: ln(x), sqrt(x), pow(x,y)
//Brackets (for changing the default priorities)
//Examples:
//(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) ---> ~ 10.6
//pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) ---> ~ 21.22
//Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".*/

using System;
using System.Collections.Generic;
using System.Text;

class MathExpressionV2              //this version uses two Stack<T> and a Queue<T> - this slightly  
{                                   //reduces the code lines and avoids indexing
    static bool IsOperator(char c)
    {
        switch (c)
        {
            case '+': return true;
            case '-': return true;
            case '*': return true;
            case '/': return true;
            case '%': return true;
            default: return false;
        }
    }

    static bool IsFunction(char c)
    {
        switch (c)
        {
            case 'l': return true;
            case 'o': return true;
            case 'g': return true;
            case 's': return true;
            case 'q': return true;
            case 'r': return true;
            case 't': return true;
            case 'p': return true;
            case 'w': return true;
            default: return false;
        }
    }

    static byte GetPresidence(string s)
    {
        switch (s)
        {
            case "+": return 1;
            case "-": return 1;
            case "*": return 2;
            case "/": return 2;
            case "%": return 2;
            case "log": return 3;
            case "sqrt": return 3;
            case "pow": return 3;
            case "(": return 0;
            default: return 0;
        }
    }

    static byte GetPresidence(char c)
    {
        switch (c)
        {
            case '+': return 1;
            case '-': return 1;
            case '*': return 2;
            case '/': return 2;
            case '%': return 2;
            case 'l': return 3;
            case 's': return 3;
            case 'p': return 3;
            case '(': return 0;
            default: return 0;
        }
    }

    static bool IsDigit(char c)
    {
        if (c - '0' >= 0 && c - '0' <= 9 || c == '.')
            return true;
        else
            return false;
    }

    static double? CalcExpression(double operandLeft, string operation)
    {
        switch (operation)
        {
            case "sqrt": return Math.Sqrt(operandLeft);
            case "ln": return Math.Log(operandLeft);
            default: return null;
        }
    }

    static double? CalcExpression(double operandLeft, double operandRight, string operation)
    {
        switch (operation)
        {
            case "+": return operandLeft + operandRight;
            case "/": return operandRight / operandLeft;
            case "*": return operandLeft * operandRight;
            case "%": return operandRight % operandLeft;
            case "-": return operandRight - operandLeft;
            case "log": return Math.Log(operandRight, operandLeft);
            case "pow": return Math.Pow(operandRight, operandLeft);
            default: return null;
        }
    }

    static void Main()
    {
        Console.WriteLine("Please input an arithmetic expression for calculation:");
        string input = Console.ReadLine();
        input = input.Replace(" ", "");
        char[] expression = input.ToCharArray();
        Queue<string> output = new Queue<string>();       //this queue contains the reverse Polish notation of the expression
        Stack<string> operations = new Stack<string>();   //this stack contains the operations
        Stack<double> operands = new Stack<double>();     //this stack contains the operands
        try
        {
            for (int i = 0; i < expression.GetLength(0); i++) //this loop generates the reverse Polish notation of the expression
            {
                if (IsDigit(expression[i]))
                {
                    StringBuilder temp = new StringBuilder();
                    while (i < expression.GetLength(0) && IsDigit(expression[i]))
                    {
                        temp.Append(expression[i]);
                        i++;
                    };
                    i--;
                    output.Enqueue(temp.ToString());
                }
                else if (i < expression.GetLength(0) && IsFunction(expression[i]))
                {
                    StringBuilder temp = new StringBuilder();
                    while (expression[i] != '(')
                    {
                        temp.Append(expression[i]);
                        i++;
                    }
                    i--;
                    operations.Push(temp.ToString());
                }
                else if (IsOperator(expression[i]))
                {
                    if (i == 0 && expression[i] == '-')
                    {
                        output.Enqueue("0");
                    }
                    if (operations.Count > 0 && GetPresidence(expression[i]) <= GetPresidence(operations.Peek()))
                    {
                        output.Enqueue(operations.Pop());
                        operations.Push(expression[i].ToString());
                    }
                    else
                    {
                        operations.Push(expression[i].ToString());
                    }
                }
                else if (expression[i] == '(')
                {
                    if (expression[i + 1] == '-')
                    {
                        output.Enqueue("0");
                        operations.Push(expression[i].ToString());
                    }
                    else
                    {
                        operations.Push(expression[i].ToString());
                    }
                }
                else if (expression[i] == ')')
                {
                    while (operations.Peek() != "(")
                    {
                        output.Enqueue(operations.Pop());
                    }
                    operations.Pop();
                    if (operations.Count != 0 && IsFunction(operations.Peek()[0]))
                    {
                        output.Enqueue(operations.Pop());
                    }
                }
                else if (expression[i] == ',')
                {
                    if (expression[i + 1] == '-')
                    {
                        output.Enqueue("0");
                    }
                    while (operations.Peek() != "(")
                    {
                        output.Enqueue(operations.Pop());
                    }
                }
            }
            while (operations.Count != 0)
            {
                output.Enqueue(operations.Pop());
            }
            do                                  //this loop calculates the value of the reverse Polish notation
            {
                double temp;
                if (double.TryParse(output.Peek(), out temp))
                {
                    operands.Push(temp);
                    output.Dequeue();
                }
                else
                {
                    double? result;
                    if (output.Peek() != "sqrt" && output.Peek() != "ln")
                    {
                        result = CalcExpression(operands.Pop(), operands.Pop(), output.Dequeue());
                    }
                    else
                    {
                        result = CalcExpression(operands.Pop(), output.Dequeue());
                    }
                    operands.Push((double)result);
                }
            }
            while (output.Count != 0);
            Console.WriteLine(operands.Peek());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid expression!");
        }
    }
}

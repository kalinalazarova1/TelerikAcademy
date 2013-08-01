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

class MathExpression            //this version uses three List<T> which play the role of stacks and a queue;
{
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
                case "/": return operandLeft / operandRight;
                case "*": return operandLeft * operandRight;
                case "%": return operandLeft % operandRight;
                case "-": return operandLeft - operandRight;
                case "log": return Math.Log(operandLeft, operandRight);
                case "pow": return Math.Pow(operandLeft, operandRight);
                default: return null;
            }
        }

        static void Main()
        {
            Console.WriteLine("Please input an arithmetic expression for calculation:");
            string input = Console.ReadLine();
            input = input.Replace(" ", "");
            char[] expression = input.ToCharArray();
            List<string> output = new List<string>();
            output.Capacity = expression.GetLength(0);      //this list contains the reverse Polish notation of the expression and performs as queue
            List<string> operations = new List<string>();   //this list contains the operations and performs as stack
            operations.Capacity = expression.GetLength(0);
            List<double> operands = new List<double>();     //this list contains the operands and perofrms as stack
            operands.Capacity = expression.GetLength(0);
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
                    output.Add(temp.ToString());
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
                    operations.Insert(0, temp.ToString());
                }
                else if(IsOperator(expression[i]))
                {
                    if (i == 0 && expression[i] == '-')
                    {
                        output.Add("0");
                    }
                    if (operations.Count > 0 && GetPresidence(expression[i]) <= GetPresidence(operations[0]))
                    {
                        output.Add(operations[0]);
                        operations.RemoveAt(0);
                        operations.Insert(0, expression[i].ToString());
                    }
                    else
                    {
                        operations.Insert(0, expression[i].ToString());
                    }
                }
                else if (expression[i] == '(')
                {
                    if (expression[i + 1] == '-')
                    {
                        output.Add("0");
                        operations.Insert(0, expression[i].ToString());
                    }
                    else
                    {
                        operations.Insert(0, expression[i].ToString());
                    }
                }
                else if (expression[i] == ')')
                {
                    while (operations[0] != "(")
                    {
                        output.Add(operations[0]);
                        operations.RemoveAt(0);
                    }
                    operations.RemoveAt(0);
                    if (operations.Count != 0 && IsFunction(operations[0][0]))
                    {
                        output.Add(operations[0]);
                        operations.RemoveAt(0);
                    }
                }
                else if (expression[i] == ',')
                {
                    if (expression[i + 1] == '-')           
                    {
                        output.Add("0");
                    }                                       
                    while (operations[0] != "(")
                    {
                        output.Add(operations[0]);
                        operations.RemoveAt(0);
                    }
                }
            }
                while (operations.Count != 0)
                {
                    output.Add(operations[0]);
                    operations.RemoveAt(0);
                }
            do                                  //this loop calculates the value of the reverse Polish notation
            {
                double temp;
                if (double.TryParse(output[0], out temp))
                {
                    operands.Insert(0, temp);
                    output.RemoveAt(0);
                }
                else
                {
                    double? result;
                    if (output[0] != "sqrt" && output[0] != "ln")
                    {
                        result = CalcExpression(operands[1], operands[0], output[0]);
                        operands.RemoveRange(0,2);   
                    }
                    else
                    {
                        result = CalcExpression(operands[0], output[0]);
                        operands.RemoveAt(0);
                    }
                    operands.Insert(0, (double)result);
                    output.RemoveAt(0);
                }
            }
            while (output.Count != 0);
            Console.WriteLine(operands[0]);
            }
        catch (Exception)
        {
            Console.WriteLine("Invalid expression!");
        }
        }
    }

using System;
using System.Collections.Generic;
using System.Text;

class BasicLanguage
{
    static void Main()
    {
        int commandCounter = -1;
        string line = Console.ReadLine();
        while (true)
        {
            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case 'P':
                        StringBuilder operand = new StringBuilder(String.Empty);
                        for (; line[i] != '('; i++) ;
                        i++;
                        if (i == line.Length)
                        {
                            line = Console.ReadLine();
                            operand.Append('\n');
                            i = 0;
                        }
                        for (; line[i] != ')'; i++)
                        {
                            if (i == line.Length)
                            {
                                line = Console.ReadLine();
                                operand.Append('\n');
                                i = 0;
                            }
                            operand.Append(line[i]);
                            if (i == line.Length - 1)
                            {
                                line = Console.ReadLine();
                                operand.Append('\n');
                                i = -1;
                            }
                        }
                        if (commandCounter == -1)
                        {
                            Console.Write(operand);
                        }
                        else
                        {
                            for (int j = 0; j < commandCounter; j++)
                            {
                                Console.Write(operand);
                            }
                        }
                        commandCounter = -1;
                        break;
                    case 'F':
                        StringBuilder operandf = new StringBuilder(String.Empty);
                        for (; line[i] != '('; i++) ;
                        i++;
                        if (i == line.Length)
                        {
                            line = Console.ReadLine();
                            i = 0;
                        }
                        int a = -1;
                        int b = 0;
                        for (; line[i] != ')'; i++)
                        {
                            if (i == line.Length)
                            {
                                line = Console.ReadLine();
                                i = 0;
                            }
                            if (line[i] == ',')
                            {
                                a = int.Parse(operandf.ToString());
                                operandf.Clear();
                            }
                            else
                            {
                                operandf.Append(line[i]);
                            }
                            if (i == line.Length - 1)
                            {
                                line = Console.ReadLine();
                                i = -1;
                            }
                        }
                        b = int.Parse(operandf.ToString());
                        if (commandCounter == -1)
                            if (a == -1) commandCounter = b;
                            else commandCounter = b - a + 1;
                        else
                            if (a == -1) commandCounter *= b;
                            else commandCounter *= b - a + 1;
                        break;
                    case 'E': Environment.Exit(0); break;
                    default: break;
                }
            }
            line = Console.ReadLine();
        }
    }
}

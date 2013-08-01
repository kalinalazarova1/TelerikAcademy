using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_19
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] simpleNumbers = new bool[10000001];       //да не я пускам така, че е много дълго решението
            simpleNumbers[0] = simpleNumbers[1] = true;      //маркирано е, че не e просто число
            for (int i = 2; i <= 10000000; i++)
            {
                if (simpleNumbers[i] == false)
                {
                    for (int j = 2; i * j <= 10000000; j++)
                    {
                        simpleNumbers[i * j] = true;
                    }
                }
            }
            for (int i = 2; i <= 10000000; i++)
            {
                if (simpleNumbers[i] == false)
                {
                    Console.Write(i + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_15
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[26];
            int letterCode = 0;
            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)((int)'A'+ i);
 
            }
            Console.WriteLine("Моля въведете дума на латиница с главни букви:");
            do
            {
                letterCode = Console.Read();
                for (int i = 0; i < 26; i++)
                {
                    if ((int)alphabet[i] == letterCode)
                    {
                        Console.Write(i + ", ");
                    }
                }
            }
           while (letterCode != 10);
           Console.WriteLine();
        }
    }
}

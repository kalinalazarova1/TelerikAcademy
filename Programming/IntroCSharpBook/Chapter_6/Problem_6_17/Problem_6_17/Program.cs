using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете първото число:");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Въведете второто число:");
            int m = Int32.Parse(Console.ReadLine());
            if (n != 0 && m != 0)
            {
                while (n != m)
                {
                    if (n > m)
                    {
                        n = n - m;
                    }
                    else
                    {
                        m = m - n;
                    }
                }
            }
            else if (n == 0)
            {
                n = m;
            }
            else
            {
                m = n;
            }
            Console.WriteLine("Най-големият им общ делител е: " + n);
        }
    }
}

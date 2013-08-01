using System;
using System.Text;

class Fire
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        for (byte i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', n / 2 - 1 - i),'#', new string('.', i * 2));
        }
        for (byte i = (byte)(n / 2 - 1); i >= n / 4; i--)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', n / 2 - 1 - i), '#', new string('.', i * 2));
        }
        Console.WriteLine("{0}", new string('-', n));
        for (byte i = 0; i < n / 2; i++)
        {
            StringBuilder sb = new StringBuilder(n);
            for (int j = 0; j < n - i * 2; j++)
            {
                if (j < (n - i * 2) / 2)
                {
                    sb.Append("\\");
                }
                else
                {
                    sb.Append("/");
                }
            }
            Console.WriteLine("{0}{1}{0}", new string('.', i), sb);
        }
    }
}

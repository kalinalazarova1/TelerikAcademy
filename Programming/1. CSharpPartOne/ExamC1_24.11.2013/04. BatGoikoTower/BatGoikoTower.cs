using System;
using System.Text;

class BatGoikoTower
{
    static void Main()
    {
        byte step = 1;
        byte crossbeam = 1;
        byte h = byte.Parse(Console.ReadLine());
        for (int i = 0; i < h; i++)
        {
            if (i == crossbeam)
            {
                step++;
                crossbeam += step;
                Console.WriteLine("{0}{1}{2}{3}{0}", new string('.', h - i - 1), '/', new string('-', i * 2), '\\');
            }
            else
            {
                Console.WriteLine("{0}{1}{2}{3}{0}", new string('.', h - i - 1), '/', new string('.', i * 2), '\\');
            }
        }
    }
}

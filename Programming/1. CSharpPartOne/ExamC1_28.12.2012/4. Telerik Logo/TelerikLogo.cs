using System;

class TelerikLogo
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', size / 2), '*', new string('.', 2 * size - 3));
        for (int i = 1; i <= size/2; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{3}{1}{2}{1}{0}", new string('.', size/2 - i),'*', new string('.', i * 2 - 1), new string('.', 2*size - 3 - i*2));
        }
        for (int i = 1; i <= size/2 - 1; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', size - 1 + i),'*',new string('.', size-2-2*i)); 
        }
        Console.WriteLine("{0}{1}{0}", new string('.', (size - 1) * 3 / 2),'*');
        for (int i = 1; i <= size - 1; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', (size - 1) * 3 / 2 - i),'*', new string('.', i*2 - 1));   
        }
        for (int i = size - 2; i >= 1; i--)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', (size - 1) * 3 / 2 - i), '*', new string('.', i * 2 - 1));  
        }
        Console.WriteLine("{0}{1}{0}", new string('.', (size - 1) * 3 / 2), '*');
    }
}

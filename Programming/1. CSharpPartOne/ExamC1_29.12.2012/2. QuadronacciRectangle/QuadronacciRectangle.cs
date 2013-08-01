using System;

class QuadronacciRectangle
{
    static void Main()
    {
        long quad_1;
        long quad_2;
        long quad_3;
        long quad_4;
        int r;
        int c;
        quad_4 = long.Parse(Console.ReadLine());
        quad_3 = long.Parse(Console.ReadLine());
        quad_2 = long.Parse(Console.ReadLine());
        quad_1 = long.Parse(Console.ReadLine());
        r = Int32.Parse(Console.ReadLine());
        c = Int32.Parse(Console.ReadLine());
        long[,] rectangle = new long[r, c];
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                long quad_cur = quad_1 + quad_2 + quad_3 + quad_4;
                rectangle[i, j] = quad_4;
                quad_4 = quad_3;
                quad_3 = quad_2;
                quad_2 = quad_1;
                quad_1 = quad_cur;
                if (j != c - 1)
                {
                    Console.Write("{0} ", rectangle[i, j]);
                }
                else
                {
                    Console.Write("{0}", rectangle[i, j]);
                }
            }
            if (i != r - 1)
            {
                Console.WriteLine();
            }
        }
    }
}

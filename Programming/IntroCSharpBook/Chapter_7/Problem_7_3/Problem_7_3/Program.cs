using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array1 = {'a', 'r', 'g', 'f'};
            char[] array2 = {'a', 'b', 'g', 'f','s'};
            int equals = 0;
            for (int i = 0; (i < array1.GetLength(0)) && (i < array1.GetLength(0)); i++)
            {
                if (array1[i] < array2[i])
                {
                    i = Math.Min(array1.GetLength(0),array2.GetLength(0));
                    equals = 1;
                }
                else if(array1[i] > array2[i])
                {
                    i = Math.Min(array1.GetLength(0),array2.GetLength(0));
                    equals = 2;
                }
            }
            if (equals == 0)
            {
                if(array1.GetLength(0)>array2.GetLength(0))
                {
                    equals = 2;
                }
                else if(array1.GetLength(0)<array2.GetLength(0))
                {
                    equals = 1;
                }

            }
            switch (equals)
            {
                case 0: Console.WriteLine("Масивите са еднакви"); break;
                case 1: Console.WriteLine("Масив 1 предшества масив 2"); break;
                case 2: Console.WriteLine("Масив 2 предшества масив 1"); break;
            }
        }
    }
}

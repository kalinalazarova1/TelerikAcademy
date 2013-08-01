using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int equal = 0;            
            Console.WriteLine("Въведете размер на масив 1:");
            int len1 = Int32.Parse(Console.ReadLine());
            int[] array1 = new int[len1];
            Console.WriteLine("Въведете размер на масив 2:");
            int len2 = Int32.Parse(Console.ReadLine());
            int[] array2 = new int[len2];
            for (int i = 0; i < len1; i++)
            {
                Console.WriteLine("масив 1, елемент [" + i + "]: ");
                array1[i] = Int32.Parse(Console.ReadLine());
            }
            for (int i = 0; i < len2; i++)
            {
                Console.WriteLine("масив 2, елемент [" + i + "]: ");
                array2[i] = Int32.Parse(Console.ReadLine());
            }
            if (len1 != len2)
            {
                equal = 1;
            }
            else
            {
                for (int i = 0; i < len1 ; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        equal = 1;
                    }
                }
            }
            Console.WriteLine(equal == 0 ? "Масивите са еднакви" : "Масивите не са еднакви");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_20
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 15, 1, 2, 4, 15, 5, 2, 6 };
            int s = 14;
            bool[] index = new bool[arr.GetLength(0)];  //съдържа true за тези числа от arr, които образуват сумата s
            int length = 0;                             //указва броя на възможните суми
            for (int l = 0; l < arr.GetLength(0); l++)  
            {                                           
                length = 1 + length * 2;
            }
            int[] sum = new int[length];
            int j = 1;
            int i = 0;
            int temp;
            for (; i < arr.GetLength(0); j++, i++)      //сумите се образуват като всяко число от arr се взема последователно
            {                                           //маркира се като възможна сума и се сумира със всички вече образувани суми последователно до достигане на s
                sum[j] = arr[i];
                temp = j;
                for (int n = 1; n < temp; n++)
                {
                    j++;
                    sum[j] = arr[i] + sum[n];
                    if (sum[j] == s)
                    {
                        break;
                    }
                }
                if (sum[j] == s)
                {
                    break;
                }
            }
            for (int l = (int)Math.Pow(2, i); i >= 0; l = l / 2, i--)   //j съдържа поредния номер на сумата която съответства на s
            {                                                           //ако го преобразуваме в двоично число там, където има true(1) съответното число от arr участва в сумата
                if (j >= l)
                {
                    index[i] = true;
                    j = j % l;
                }
            }
            Console.WriteLine("Сумата " + s + " е образувана от числата:");
            for (int l = 0; l < arr.GetLength(0); l++)
            {
                if (index[l] == true)
                {
                    Console.Write(arr[l] + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}

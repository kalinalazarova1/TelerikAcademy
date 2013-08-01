using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_21
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 15, 1, 3, 4, 15, 5, 2, 6 };
            int s = 14;
            int k = 3;
            int count = 0;
            bool[] index;                               //съдържа true за тези числа от arr, които образуват сумата s
            int length = 0;                             //указва броя на възможните суми
            for (int l = 0; l < arr.GetLength(0); l++)
            {
                length = 1 + length * 2;
            }
            int[] sum = new int[length + 1];            // тъй като започвам да пълня масива от 1 затова трябва да е дължината му е увеличена с 1
            int j = 1;
            int i = 0;
            while (j < sum.GetLength(0))
            {
                for (; i < arr.GetLength(0); j++, i++)      //сумите се образуват като всяко число от arr се взема последователно
                {                                           //маркира се като възможна сума и се сумира със всички вече образувани суми последователно до достигане на s
                    sum[j] = arr[i];
                    int currPosition = j;
                    for (int n = 1; n < currPosition; n++)
                    {
                        j++;
                        sum[j] = arr[i] + sum[n];
                        if (sum[j] == s)
                        {
                            int sumPosition = j;
                            int arrPosition = i;
                            count = 0;
                            index = new bool[arr.GetLength(0)];
                            for (int l = (int)Math.Pow(2, arrPosition); arrPosition >= 0; l = l / 2, arrPosition--)   //j съдържа поредния номер на сумата която съответства на s
                            {                                                                                        //ако го преобразуваме в двоично число там, където има true(1) съответното число от arr участва в сумата
                                if (sumPosition >= l)
                                {
                                    index[arrPosition] = true;
                                    sumPosition = sumPosition % l;
                                    count++;
                                }
                            }
                            if (count == k)
                            {
                                Console.WriteLine("Сумата " + s + " е образувана от числата:");
                                for (int l = 0; l < arr.GetLength(0); l++)
                                {
                                    if (index[l] == true)
                                    {
                                        Console.Write(arr[l] + ", ");
                                    }
                                }
                                Console.WriteLine();
                                break;
                            }
                        }
                    }
                    if (count == k)
                        break;
                }
                if (count == k)
                    break;
            }
            if (j == sum.GetLength(0))
            {
                Console.WriteLine("Няма такива {0} числа сумата, на които да е {1}.", k, s);
            }
        }
    }
}

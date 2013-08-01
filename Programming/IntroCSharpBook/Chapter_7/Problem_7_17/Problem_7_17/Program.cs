using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_17
{
    class Program
    {
        static void Main(string[] args)
        {           
            int[] arr = { 23, 43, 37, 68, 98, 11, 15, 23, 32, 87, 56, 34, 67, 24, 17, 8 };
            int [] res = new int[arr.GetLength(0)];
            for (int len = 1; len <= arr.GetLength(0) / 2; len = len * 2)       //определя дължината на подмасива
            {                       
                int[] temp1 = new int[len * 2];
                for (int j = 0; j < arr.GetLength(0) / (len * 2); j++)  //показва колко подмасива има за дадена дължина на подмасива
                {
                    int cs = 0;
                    int ce = 0;
                    for (int i = 0; i < 2 * len; i++)               //слива двата подмасива като ги сортира в масива temp1[]
                    {
                        if (cs < len && len + j * 2 * len + ce < arr.GetLength(0) && arr[j * 2 * len + cs] <= arr[len + j * 2 * len + ce])
                        {
                            temp1[i] = arr[j*2*len + cs];
                            cs++;
                        }
                        else if ( ce < len && len + j * 2 * len + ce < arr.GetLength(0) && arr[len + j*2*len + ce] < arr[j*2*len + cs])
                        {
                            temp1[i] = arr[len + j*2*len + ce];
                            ce++;
                        }
                        else if (cs == len)
                        {
                            temp1[i] = arr[len + j*2*len + ce];
                            ce++;
                        }
                        else if (ce == len)
                        {
                            temp1[i] = arr[j*2*len + cs];
                            cs++;
                        }
                        res[i + j*2*len] = temp1[i];      //прехвърля последователно в res[] всички сляти масиви temp[] за дадения етап от сортирането
                    }   
                }
                if (arr.GetLength(0) % (len * 2) != 0)      // ако елементите на масива не са кратни на степените на 2 сортира остатъка за всеки етап т.е. дължина на подмасива
                {
                    int[] res1 = new int[len * 2 + arr.GetLength(0) % (len * 2)];
                    int cs = 0;
                    int ce = 0;
                    int[] temp = new int[len * 2 + arr.GetLength(0) % (len * 2)];
                    for (int i = 0; i < res1.GetLength(0) - arr.GetLength(0) % (len * 2); i++)
                    {
                        res1[i] = res[arr.GetLength(0) - len * 2 - arr.GetLength(0) % (len * 2) + i];
                    }
                    for (int i = 0; i < temp.GetLength(0); i++)
                    {
                        if (cs < 2 * len && ce < arr.GetLength(0) % (len * 2) && arr[arr.GetLength(0) - arr.GetLength(0) % (len * 2) + ce] < res1[cs])
                        {
                            temp[i] = arr[arr.GetLength(0) - arr.GetLength(0) % (len * 2) + ce];
                            ce++;
                        }
                        else if (cs < 2 * len && ce < arr.GetLength(0) % (len * 2) && arr[arr.GetLength(0) - arr.GetLength(0) % (len * 2) + ce] >= res1[cs])
                        {
                            temp[i] = res1[cs];
                            cs++;
                        }
                        else if (ce == arr.GetLength(0) % (len * 2))
                        {
                            temp[i] = res1[cs];
                            cs++;
                        }
                        else if (cs == 2 * len)
                        {
                            temp[i] = arr[arr.GetLength(0) - arr.GetLength(0) % (len * 2) + ce];
                            ce++;
                        }
                        res[arr.GetLength(0) - len * 2 - arr.GetLength(0) % (len * 2) + i] = temp[i];
                    }
                }
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    arr[i] = res[i];                    //прехвърля последователно в arr[] масива res[] за дадения етап от сортирането
                }
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}

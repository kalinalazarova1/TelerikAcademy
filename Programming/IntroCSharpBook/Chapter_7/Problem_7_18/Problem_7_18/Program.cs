using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 23, 16, 32, 7, 13, 12, 1, 10, 9, 81, 56, 6, 5, 14, 3, 22, 9 };
            int[] temp = new int[arr.GetLength(0)];
            int r = arr.GetLength(0) - 1;
            int l = 0;
            bool[] isSorted = new bool[arr.GetLength(0)];
            while(true)
            {      
                    int tl = l;
                    int tr = r;
                    for(int i = l; i <= r; i++)
                    {
                        if(arr[i] < arr[r])
                        {
                            temp[tl] = arr[i];
                            tl++;
                        }
                        else if(arr[i] >= arr[r])
                        {
                            temp[tr] = arr[i];
                            tr--;
                        }
                    
                    }
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        arr[i] = temp[i];
                    }
                    isSorted[tl] = true;
                int index = 0;
                while (index < isSorted.GetLength(0) && isSorted[index] == true)
                {
                    index++;
                }
                l = index;
                while (index < isSorted.GetLength(0) && isSorted[index] == false)
                {
                    index++;
                }
                r = index - 1;
                if (index == isSorted.GetLength(0) && l == r)
                {
                    break;
                }
            }                
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}

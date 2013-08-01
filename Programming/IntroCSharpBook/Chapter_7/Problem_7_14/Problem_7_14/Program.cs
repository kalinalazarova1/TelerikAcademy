using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_14
{
    class Program
    {
        static void Main(string[] args)
        {           
            int len;
            int bestLen = 1;
            int currRow = 0;
            int currCol = 0;
            string bestString = null;
            string[,] arr = {
                             {"ha","ho","ho","hi"},
                             {"fo","ho","hi","xx"},
                             {"xx","hi","ha","xx"},
                             {"hi","ho","hi","ho"},
                             {"fo","ho","hi","xx"}
                         };
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    len = 1;
                    currRow = i;
                    currCol = j;
                    while((currRow != arr.GetLength(0) - 1) && arr[currRow, currCol] == arr[currRow + 1, currCol])
                    {           
                        len++;
                        if (len > bestLen)
                        {
                            bestLen = len;
                            bestString = arr[currRow, currCol];
                        }
                        currRow++; 
                        if (currRow == (arr.GetLength(0) - 1))
                        {
                            break;
                        }
                    }
                    
                    len = 1;
                    currRow = i;
                    currCol = j;
                    while ((currCol != arr.GetLength(1) - 1) && arr[currRow, currCol] == arr[currRow, currCol + 1])
                    {
                        len++;
                        if (len > bestLen)
                        {
                            bestLen = len;
                            bestString = arr[currRow, currCol];
                        }
                        currCol++;
                        if (currCol == (arr.GetLength(1) - 1))
                        {
                            break;
                        }
                    }
                    
                    len = 1;
                    currRow = i;
                    currCol = j;
                    while (currCol != (arr.GetLength(1) - 1) && currRow != (arr.GetLength(0) - 1) && arr[currRow, currCol] == arr[currRow + 1, currCol + 1])
                    {
                        len++;
                        if (len > bestLen)
                        {
                            bestLen = len;
                            bestString = arr[currRow, currCol];
                        }
                        currRow++;
                        currCol++;
                        if ((currRow == (arr.GetLength(0) - 1)) || (currCol == (arr.GetLength(1) - 1)))
                        {
                            break;
                        }
                    }
                    len = 1;
                    currRow = i;
                    currCol = j;
                    while (currCol != 0 && currRow != (arr.GetLength(0) - 1) && arr[currRow, currCol] == arr[currRow + 1, currCol - 1])
                    {
                        len++;
                        if (len > bestLen)
                        {
                            bestLen = len;
                            bestString = arr[currRow, currCol];
                        }
                        currRow++;
                        currCol--;
                        if ((currRow == (arr.GetLength(0) - 1)) || (currCol == 0))
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Най-дългата поредица е от {0} и се среща {1} пъти.", bestString, bestLen);
        }
    }
}

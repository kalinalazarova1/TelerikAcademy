using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7_27
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = {{1, 3, 2, 2, 2, 4},                       // обхожда масива по алгоритъма DFS (Depth-first-search)
                          {3, 3, 3, 2, 4, 4},
                          {4, 3, 1, 2, 3, 3},
                          {4, 3, 1, 3, 3, 1},
                          {4, 3, 3, 3, 1, 1}};
            int bestCount = 0;
            int bestCell = 0;
            bool[,] read = new bool[arr.GetLength(0),arr.GetLength(1)];
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    int count = 1;
                    int[] route = new int[arr.GetLength(0) * arr.GetLength(1)]; // показва маршрута, по който сме стигнали до дадения елемент
                    int indexRoute = 0;                                         
                    int currentRow = row;
                    int currentCol = col;
                    read[currentRow, currentCol] = true;    // указва дали даден елемент е прочетен
                    route[indexRoute] = currentRow * arr.GetLength(1) + currentCol; 
                    indexRoute++;
                    int closedDirection = 0;                // показва забранената посоката на движение (по подразбиране е 0, т.е. разрешено е движение навсякъде),
                               // 1 - забранено е нагоре, 2 - забранено е и наляво, 3 - забранено е и надолу, 4 - забранено е навсякъде 
                    do
                    {
                        if (closedDirection == 4)
                        {
                            indexRoute = indexRoute - 1;
                            currentRow = route[indexRoute] / arr.GetLength(1);
                            currentCol = route[indexRoute] % arr.GetLength(1);
                        }
                        if (currentRow > 0 && arr[currentRow, currentCol] == arr[currentRow - 1, currentCol] && closedDirection != 3 && closedDirection != 2 && closedDirection != 1)
                        {
                            if (read[currentRow - 1, currentCol] == false)
                            {
                                count++;
                                if (count > bestCount)
                                {
                                    bestCount = count;
                                    bestCell = arr[currentRow - 1, currentCol];
                                }
                                read[currentRow - 1, currentCol] = true;
                                route[indexRoute] = currentRow * arr.GetLength(1) + currentCol;
                                indexRoute++;
                                currentRow = currentRow - 1;
                                closedDirection = 0;
                            }
                            else
                            {
                                closedDirection = 1;
                            }
                        }
                        else if (currentCol > 0 && arr[currentRow, currentCol] == arr[currentRow, currentCol - 1] && closedDirection != 2 && closedDirection != 3)
                        {
                            if (read[currentRow, currentCol - 1] == false)
                            {
                                count++;
                                if (count > bestCount)
                                {
                                    bestCount = count;
                                    bestCell = arr[currentRow, currentCol - 1];
                                }
                                read[currentRow, currentCol - 1] = true;
                                route[indexRoute] = currentRow * arr.GetLength(1) + currentCol;
                                indexRoute++;
                                currentCol = currentCol - 1;
                                closedDirection = 0;
                            }
                            else
                            {
                                closedDirection = 2;
                            }
                        }
                        else if (currentRow < arr.GetLength(0) - 1 && arr[currentRow, currentCol] == arr[currentRow + 1, currentCol] && closedDirection != 3)
                        {
                            if (read[currentRow + 1, currentCol] == false)
                            {
                                count++;
                                if (count > bestCount)
                                {
                                    bestCount = count;
                                    bestCell = arr[currentRow + 1, currentCol];
                                }
                                read[currentRow + 1, currentCol] = true;
                                route[indexRoute] = currentRow * arr.GetLength(1) + currentCol;
                                indexRoute++;
                                currentRow = currentRow + 1;
                                closedDirection = 0;
                            }
                            else
                            {
                                closedDirection = 3;
                            }
                        }
                        else if (currentCol < arr.GetLength(1) - 1 && arr[currentRow, currentCol] == arr[currentRow, currentCol + 1])
                        {
                            if (read[currentRow, currentCol + 1] == false)
                            {
                                count++;
                                if (count > bestCount)
                                {
                                    bestCount = count;
                                    bestCell = arr[currentRow, currentCol + 1];
                                }
                                read[currentRow, currentCol + 1] = true;
                                route[indexRoute] = currentRow * arr.GetLength(1) + currentCol;
                                indexRoute++;
                                currentCol = currentCol + 1;
                                closedDirection = 0;
                            }
                            else
                            {
                                closedDirection = 4;
                            }
                        }
                        else
                        {
                            closedDirection = 4;
                        }
                    }
                    while (!(indexRoute == 1 && closedDirection == 4));
                }
            }
            Console.WriteLine("Най-дългата поредица е образувана от {0} и съдържа {1} елемента.", bestCell, bestCount); 
        } 
    }
}

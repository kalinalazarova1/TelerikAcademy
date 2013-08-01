//We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0.
//Example:3, -2, 1, 1, 8 ->  1 + 1 -2 = 0

using System;

class SumOfSubsets
{
    static void Main()
    {
        int[] inputNumbers = {3, -2, 1, 1, 8};
        int[] possibleSum = new int[(int)Math.Pow(2,inputNumbers.Length)];
        int index = 1;
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            possibleSum[index] = inputNumbers[i];
            int tempIndex = index;
            index++;
            for (int j = 1; j < tempIndex; j++, index++)
            {
                possibleSum[index] = possibleSum[j] + inputNumbers[i];
                if (possibleSum[index] == 0)
                {
                    int positionCode = index;
                    for (int n = 0; n < inputNumbers.Length; n++, positionCode /= 2)
                        if (positionCode % 2 == 1)
                        {
                            Console.Write("Number {0}: Value: {1} ", n + 1, inputNumbers[n]);
                        }
                    Console.WriteLine("make sum {0}", possibleSum[index]);
                }
            }
        } 
    }
}

//16.* We are given an array of integers and a number S. Write a program to find if there exists a
 //subset of the elements of the array that has a sum S. Example: arr = {2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6).

using System;

class SubsetsSumS
{
    static void Main()
    {
        int[] inputNumbers = { 2, 1, 2, 4, 3, 5, 2, 6};
        int s = 14;
        int[] possibleSum = new int[(int)Math.Pow(2, inputNumbers.Length)];
        int index = 1;
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            possibleSum[index] = inputNumbers[i];
            int tempIndex = index;
            index++;
            for (int j = 1; j < tempIndex; j++, index++)
            {
                possibleSum[index] = possibleSum[j] + inputNumbers[i];
                if (possibleSum[index] == s)
                {
                    int positionCode = index;
                    for (int n = 0; n < inputNumbers.Length; n++, positionCode /= 2)
                        if (positionCode % 2 == 1)
                        {
                            Console.WriteLine("Element {0}: {1} ", n , inputNumbers[n]);
                        }
                    Console.WriteLine("make sum {0}", possibleSum[index]);
                }
            }
        }
    }
}

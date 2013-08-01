//*Write a program that reads a positive integer number N (N < 20) from the console
//and outputs in the console the numbers 1...N numbers arranged as a spiral
//Example: for N = 4
//      1  2  3  4
//      12 13 14 5
//      11 16 15 6
//      10  9  8 7

using System;

class SpiralNumbers
{
    static void Main()
    {
        int counter = 1;    //generates the numbers which fill the square
        byte size;           //square side size
        bool isValid;
        do
        {
            Console.WriteLine("Please input the size of the matrix N < 20:");
            isValid = byte.TryParse(Console.ReadLine(), out size);
        }
        while (!isValid || size >= 20);
        int[,] matrix = new int[size, size];
        for (int g = 0; g < (size / 2); g++)               //move the starting and ending point for each square filled with numbers
        {
            for (int i = 0 + g; i <= size - 2 - g; i++)    //fills the left side of the square
            {
                matrix[0 + g, i] = counter;
                counter++;
            }
            for (int i = 0 + g; i <= size - 2 - g; i++)    //fills the down side of the square
            {
                matrix[i, size - 1 - g] = counter;
                counter++;
            }
            for (int i = size - 1 - g; i > 0 + g; i--)     //fills the right side of the square
            {
                matrix[size - 1 - g, i] = counter;
                counter++;
            }
            for (int i = size - 1 - g; i > 0 + g; i--)     //fills the upper side of the square
            {
                matrix[i, 0 + g] = counter;
                counter++;
            }

        }
        if ((size & 1) == 1)                                  //if the matrix side size is odd draws the center cell
        {
            matrix[size / 2, size / 2] = size * size;
        }
        for (int rows = 0; rows <= size - 1; rows++)           //prints the entire matrix
        {
            for (int columns = 0; columns <= size - 1; columns++)
            {
                Console.Write("{0,4}", matrix[rows, columns]);
            }
            Console.WriteLine();
        }
    }
}

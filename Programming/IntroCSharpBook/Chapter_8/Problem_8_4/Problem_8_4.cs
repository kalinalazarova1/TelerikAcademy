using System;

class Problem_8_4
    {
        static void Main()
        {
            int decNumber;
            int[] arr = new int[32];
            int i;
            Console.WriteLine("Please input decimal number:");
            decNumber = Int32.Parse(Console.ReadLine());
            Console.Write("The binary equivalent of {0} is: ", decNumber);
            for (i = 0; i < 32 && decNumber > 0; i++)
            {
                arr[i] = decNumber % 2;
                decNumber /= 2;
            }
            while (i > 0)
            {
                i--;
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
    }

using System;

class Problem_8_7
{
    static void Main()
    {
        int decNumber = 0;
        char[] arr = new char[32];
        int temp = 0;
        int i = 0;
        int powerOfSixteen = 1;
        Console.WriteLine("Please input heximal number:");
        while (temp != 10)
        {
            temp = Console.Read();
            arr[i] = Convert.ToChar(temp);
            i++;
        }
        Console.Write("The decimal equivalent of ");
        i -= 3;
        for (int j = 0; j <= i; j++)
        {
            Console.Write(arr[j]);
        }
        Console.Write(" is: ");
        while (i >= 0)
        {
            switch (arr[i])
            {
                case '0': break;
                case '1': decNumber += powerOfSixteen * 1; break;
                case '2': decNumber += powerOfSixteen * 2; break;
                case '3': decNumber += powerOfSixteen * 3; break;
                case '4': decNumber += powerOfSixteen * 4; break;
                case '5': decNumber += powerOfSixteen * 5; break;
                case '6': decNumber += powerOfSixteen * 6; break;
                case '7': decNumber += powerOfSixteen * 7; break;
                case '8': decNumber += powerOfSixteen * 8; break;
                case '9': decNumber += powerOfSixteen * 9; break;
                case 'A': decNumber += powerOfSixteen * 10; break;
                case 'B': decNumber += powerOfSixteen * 11; break;
                case 'C': decNumber += powerOfSixteen * 12; break;
                case 'D': decNumber += powerOfSixteen * 13; break;
                case 'E': decNumber += powerOfSixteen * 14; break;
                case 'F': decNumber += powerOfSixteen * 15; break;
            }
            powerOfSixteen *= 16;
            i--;
        }
        Console.Write(decNumber);
        Console.WriteLine();
    }
}


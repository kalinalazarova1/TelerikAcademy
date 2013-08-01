using System;

class Problem_8_13
{
    static void Main()
    {
        int decNumber = 0;
        char[] arr = new char[32];
        int[] input = new int[32];
        int s;
        int d;
        int temp = 0;
        int i = 0;
        int[] res = new int[8];
        Console.WriteLine("Please specify the input digital system (number between 2 and 36):");
        s = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please specify the output digital system (number between 2 and 36):");
        d = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input number in {0} digital system:", s);
        while (temp != 10)
        {
            temp = Console.Read();
            arr[i] = Convert.ToChar(temp);
            i++;
        }
        Console.Write("The equivalent in {0} digital system is: ", d);
        i -= 3;
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            switch (arr[j])
            {
                case '0': input[j] = 0; break;
                case '1': input[j] = 1; break;
                case '2': input[j] = 2; break;
                case '3': input[j] = 3; break;
                case '4': input[j] = 4; break;
                case '5': input[j] = 5; break;
                case '6': input[j] = 6; break;
                case '7': input[j] = 7; break;
                case '8': input[j] = 8; break;
                case '9': input[j] = 9; break;
                case 'A': input[j] = 10; break;
                case 'B': input[j] = 11; break;
                case 'C': input[j] = 12; break;
                case 'D': input[j] = 13; break;
                case 'E': input[j] = 14; break;
                case 'F': input[j] = 15; break;
                case 'G': input[j] = 16; break;
                case 'H': input[j] = 17; break;
                case 'I': input[j] = 18; break;
                case 'J': input[j] = 19; break;
                case 'K': input[j] = 20; break;
                case 'L': input[j] = 21; break;
                case 'M': input[j] = 22; break;
                case 'N': input[j] = 23; break;
                case 'O': input[j] = 24; break;
                case 'P': input[j] = 25; break;
                case 'Q': input[j] = 26; break;
                case 'R': input[j] = 27; break;
                case 'S': input[j] = 28; break;
                case 'T': input[j] = 29; break;
                case 'U': input[j] = 30; break;
                case 'V': input[j] = 31; break;
                case 'W': input[j] = 32; break;
                case 'X': input[j] = 33; break;
                case 'Y': input[j] = 34; break;
                case 'Z': input[j] = 35; break;
                default: break;
            }
        }
        for (int j = i; j >= 0; j--)
        {
            decNumber = decNumber + input[j] * Convert.ToInt32(Math.Pow(s, i - j));
        }
        for (i = 0; i < 32 && decNumber > 0; i++)
        {
            res[i] = decNumber % d;
            decNumber /= d;
        }
        while (i > 0)
        {
            i--;
            switch (res[i])
            {
                case 10: Console.Write("A"); break;
                case 11: Console.Write("B"); break;
                case 12: Console.Write("C"); break;
                case 13: Console.Write("D"); break;
                case 14: Console.Write("E"); break;
                case 15: Console.Write("F"); break;
                case 16: Console.Write("G"); break;
                case 17: Console.Write("H"); break;
                case 18: Console.Write("I"); break;
                case 19: Console.Write("J"); break;
                case 20: Console.Write("K"); break;
                case 21: Console.Write("L"); break;
                case 22: Console.Write("M"); break;
                case 23: Console.Write("N"); break;
                case 24: Console.Write("O"); break;
                case 25: Console.Write("P"); break;
                case 26: Console.Write("Q"); break;
                case 27: Console.Write("R"); break;
                case 28: Console.Write("S"); break;
                case 29: Console.Write("T"); break;
                case 30: Console.Write("U"); break;
                case 31: Console.Write("V"); break;
                case 32: Console.Write("W"); break;
                case 33: Console.Write("X"); break;
                case 34: Console.Write("Y"); break;
                case 35: Console.Write("Z"); break;
                default: Console.Write(res[i]); break;
            }
        }
        Console.WriteLine();
    }
}


//10. Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method
//that multiplies a number represented as array of digits by given integer number.

using System;

class _Factoriel
{
    static byte[] GetMaxArray(byte[] first, byte[] second)
    {
        return first.Length > second.Length ? first : second;
    }

    static byte[] TrimArray(byte[] arr)             //Trims the first leading zeros (starting from arr[0]) from array
    {
        byte i = 0;
        while (arr[i] == 0)
        {
            i++;
        }
        byte[] result = new byte[arr.Length - i];
        for (byte j = 0; j < result.Length; j++, i++)
        {
            result[j] = arr[i];
        }
        return result;
    }

    static byte[] AddBigNumbers(byte[] first, byte[] second)
    {
        Array.Reverse(first);       //all the logic of the method is based on array of digits where in arr[0] is kept the first digits
        second = TrimArray(second);  // and therefore the arrays should be reversed before adding
        Array.Reverse(second);
        byte[] result = new byte[(first.Length >= second.Length ? first.Length : second.Length) + 1];
        for (int i = 0; i < Math.Max(first.Length, second.Length); i++)
        {
            if (i < Math.Min(first.Length, second.Length))
            {
                result[i + 1] = (byte)((first[i] + second[i] + result[i]) / 10);    //keeps the remainder (when the sum is > 10) in the next position result[i + 1]; 
                result[i] = (byte)((first[i] + second[i] + result[i]) % 10);        //adds the numbers on the current position and writes in result[i] only the part less than 10;
            }
            else
            {
                result[i + 1] = (byte)((GetMaxArray(first, second)[i] + result[i]) / 10); //adds in result only the longer array
                result[i] = (byte)((GetMaxArray(first, second)[i] + result[i]) % 10);
            }
        }
        Array.Reverse(first);       //returns the original order of the first array, because the reversion affects the original array
        Array.Reverse(result);      //the result is reversed in order to fill the condition in arr[0] to be the last digit
        return result;
    }

    static byte[] ConvertToBigNumber(byte n)   //converts a number to array of digits
    {
        byte[] bigNumber = new byte[n.ToString().Length];
        for (int i = bigNumber.Length - 1; n > 0; n /= 10, i--)
        {
            bigNumber[i] = (byte)(n % 10);
        }
        return bigNumber;
    }

    static byte[] MultiplyBigNumbers(byte[] bigNumber, byte number)  //uses the idea that multiplication of 3*4 is equal to 4+4+4
    {
        byte[] result = new byte[bigNumber.Length + number.ToString().Length];
        bigNumber.CopyTo(result, result.Length - bigNumber.Length);
        for (byte i = 0; i < number - 1; i++)
        {
            result = TrimArray(AddBigNumbers(bigNumber, result));
        }
        return result;
    }

    static byte[] Factoriel(byte number)
    {
        byte[] result = ConvertToBigNumber(number);
        for (byte i = (byte)(number - 1); i > 1 ; i--)
        {
            result = MultiplyBigNumbers(result, i);
        }
        return TrimArray(result);
    }

    static void PrintBigNumber(byte[] bigNumber)
    {
        for (int i = 0; i < bigNumber.Length; i++)
        {
            Console.Write(bigNumber[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        byte n;
        do
        {
            Console.WriteLine("Please input number between 1 and 100:");
            n = byte.Parse(Console.ReadLine());
        }
        while (n < 1 || n > 100);
        Console.WriteLine("Factoriel of number {0} is:", n);
        PrintBigNumber(Factoriel(n));
    }
}

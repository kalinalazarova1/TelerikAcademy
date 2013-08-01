//8. Write a method that adds two positive integer numbers represented by array of digits
//(each element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the
//numbers that will be added could contain up to 10 000 digits.

using System;

class BigNumbers
{
    static void PrintBigNumber(byte[] number)
    {
        if (number.Length == 0)
        {
            throw new IndexOutOfRangeException("The number should contain at least one digit.");
        }
        for (int i = number[0] == 0 ? 1 : 0; i < number.Length; i++)
        {
            Console.Write(number[i]);
        }
        Console.WriteLine();
    }

    static byte[] GetMaxArray(byte[] first, byte[] second)
    {
        return first.Length > second.Length ? first : second;
    }

    static byte[] AddBigNumbers(byte[] first, byte[] second)
    {
        if (first.Length == 0 || second.Length == 0)        //in this Main() this exeption is not reachable but used in another program could be reached;
        {
            throw new IndexOutOfRangeException("The number should contain at least one digit.");
        }
        Array.Reverse(first); //all the logic of the method is based on array of digits where in arr[0] is kept the first digits
        Array.Reverse(second);// and therefore the arrays should be reversed before adding
        byte[] result = new byte[(first.Length >= second.Length ? first.Length: second.Length) + 1];
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
        Array.Reverse(result);      //the result is reversed in order to fill the condition in arr[0] to be the last digit
        return result;
    }

    static void Main()
    {
        byte[] firstNumber = {9, 9, 9, 9};
        byte[] secondNumber = {1, 9, 9, 9, 9};
        try
        {
            Console.WriteLine("First number:");
            PrintBigNumber(firstNumber);
            Console.WriteLine("Second number:");
            PrintBigNumber(secondNumber);
            Console.WriteLine("Sum:");
            PrintBigNumber(AddBigNumbers(firstNumber, secondNumber));
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

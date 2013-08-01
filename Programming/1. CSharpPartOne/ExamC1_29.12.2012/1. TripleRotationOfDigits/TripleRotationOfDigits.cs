using System;

class TripleRotationOfDigits
{
    static void Main()
    {
        int resultDigit = 0;
        string startDigit;
        string tempDigit;
        char rotatedDigit;
        startDigit = Console.ReadLine();
        for (int i = 0; i < 3; i++)
        {
            rotatedDigit = startDigit[startDigit.Length - 1];
            startDigit = startDigit.Remove(startDigit.Length - 1);
            startDigit = rotatedDigit + startDigit;
            resultDigit = int.Parse(startDigit);
            startDigit = resultDigit.ToString();
        }
        Console.WriteLine(resultDigit);
    }
}

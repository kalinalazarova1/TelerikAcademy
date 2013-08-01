//*Write a program that converts the number in the range [0...999] to a text corresponding to
//its English pronunciation. Examples:
//0  ->Zero;
//273->Two hundred seventy three;
//400->Four hundred;
//501->Five hundred and one;
//711->Seven hundred and eleven;

using System;

class EnglishNumbers
{
    static void Main()              //this version is with arrays and the code lines are significantly less
    {
        string[] units = {"zero","one","two","three","four","five","six","seven","eight","nine"}; 
        string[] tens = {"twenty","thirty","fourty","fifty","sixty","seventy","eighty","ninety"};
        string[] teens = { "ten","eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"};
        string numberByWords, numberHundreds, numberTens, numberUnits;
        int numberByDigits;
        bool isValid;
        numberHundreds = numberTens = numberUnits = null;
        do
        {
            Console.WriteLine("Please input an integer number from the interval [0, 999]:");
            isValid = Int32.TryParse(Console.ReadLine(), out numberByDigits);
        }
        while (numberByDigits > 999 || numberByDigits < 0 || !isValid);
        if (numberByDigits / 100 > 0)
        {
            numberHundreds = units[numberByDigits / 100] + " hundred";  //return the hundreds
            numberByDigits %= 100;
        }
        if (numberByDigits / 10 > 1)
        {
            numberTens = tens[numberByDigits / 10 - 2];             //returns the tens if they are >= 20
            if (numberByDigits % 10 != 0)
            {
                numberUnits = units[numberByDigits % 10];           //returns the units when tens are not null
            }
        }
        else if (numberByDigits / 10 == 1)
        {
            numberUnits = teens[numberByDigits % 10];                   //returns numbers from 10 to 19
        }
        else if(numberHundreds != null && numberByDigits % 10 == 0)
        {
            numberUnits = null;                                     //return numbers like 100, 200, 300
        }
        else
        {
            numberUnits = units[numberByDigits % 10];       //returns units when tens are null
        }
        if (numberHundreds != null)                          //formats the spaces and "and" for the output string
        {
            if (numberTens != null)
            {
                numberByWords = numberHundreds + " " + numberTens + " " + numberUnits;
            }
            else
            {
                if (numberUnits != null)
                {
                    numberByWords = numberHundreds + " and " + numberUnits;
                }
                else
                {
                    numberByWords = numberHundreds;
                }
            }
        }
        else
        {
            if (numberTens != null)
            {
                numberByWords = numberTens + " " + numberUnits;
            }
            else
            {
                numberByWords = numberUnits;
            }
        }
        numberByWords = char.ToUpper(numberByWords[0]) + numberByWords.Substring(1);    //Makes first letter uppercase
        Console.WriteLine(numberByWords);                                               //Prints the result
        
    }
}
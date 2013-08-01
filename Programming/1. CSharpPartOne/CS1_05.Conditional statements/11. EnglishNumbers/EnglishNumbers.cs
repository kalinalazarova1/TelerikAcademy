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
    static string GetEnglishDigit(int digit)        //Returns the English word for the corresponding digit
    {
        switch (digit)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default: return null;
        }
    }

    static void Main()
    {
        string numberByWords, numberHundreds, numberTens, numberUnits;
        int numberByDigits;
        numberHundreds = numberTens = numberUnits = null;
        bool isValid;
        do
        {
            Console.WriteLine("Please input an integer number from the interval [0, 999]:");
            isValid = Int32.TryParse(Console.ReadLine(), out numberByDigits);
        }
        while (numberByDigits > 999 || numberByDigits < 0 || !isValid);
            if (numberByDigits / 100 > 0)
            {
                numberHundreds = GetEnglishDigit(numberByDigits / 100) + " hundred";    //Gets the hundreds name;
                numberByDigits %= 100;                                                  //Eliminates the hundreds from the number
            }
            if (numberByDigits != 0)                //if there are tens and units the program gets them
            {
                switch (numberByDigits / 10)        //Gets the tens
                {
                    case 0:
                        numberUnits = GetEnglishDigit(numberByDigits % 10);  //Gets the units when there are no tens
                        break;
                    case 1:
                        switch (numberByDigits % 10)                        //Gets the number from 10 to 19
                        {
                            case 0: numberUnits = "ten"; break;
                            case 1: numberUnits = "eleven"; break;
                            case 2: numberUnits = "twelve"; break;
                            case 3: numberUnits = "thirteen"; break;
                            case 4: numberUnits = "fourteen"; break;
                            case 5: numberUnits = "fifteen"; break;
                            case 6: numberUnits = "sixteen"; break;
                            case 7: numberUnits = "seventeen"; break;
                            case 8: numberUnits = "eighteen"; break;
                            case 9: numberUnits = "nineteen"; break;
                        }
                        numberByDigits = numberByDigits - numberByDigits % 10 - 10; //Eliminates the tens when they are between 10 and 19
                        break;
                    case 2: numberTens = "twenty"; break;
                    case 3: numberTens = "thirty"; break;
                    case 4: numberTens = "fourty"; break;
                    case 5: numberTens = "fifty"; break;
                    case 6: numberTens = "sixty"; break;
                    case 7: numberTens = "seventy"; break;
                    case 8: numberTens = "eighty"; break;
                    case 9: numberTens = "ninety"; break;
                }
                if (numberByDigits % 10 > 0)                         //returns the units names when there are tens
                {
                    numberUnits = GetEnglishDigit(numberByDigits %= 10);
                }
            }
           else if (numberHundreds == null)
            {
                numberUnits = "zero";                            //returns zero for number 0
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
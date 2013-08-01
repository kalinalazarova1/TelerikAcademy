//Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it
//Use a sequence of if statements.

using System;

class ProductSign
{
    static void Main()
    {
        double firstReal, secondReal, thirdReal;
        bool isNegativeSign = false;
        bool isValid;
        do
        {
            Console.WriteLine("Please enter the first real number:");
            isValid = double.TryParse(Console.ReadLine(), out firstReal);
        }
        while (!isValid);
        do
        {
            Console.WriteLine("Please enter the second real number:");
            isValid = double.TryParse(Console.ReadLine(), out secondReal);
        }
        while (!isValid);
        do
        {
            Console.WriteLine("Please enter the third real number:");
            isValid = double.TryParse(Console.ReadLine(), out thirdReal);
        }
        while (!isValid);

        if (firstReal < 0 && secondReal < 0 && thirdReal < 0)
        {
            isNegativeSign = true;
        }
        else if (firstReal < 0 && secondReal > 0 && thirdReal > 0)
        {
            isNegativeSign = true;
        }
        else if (firstReal > 0 && secondReal < 0 && thirdReal > 0)
        {
            isNegativeSign = true;
        }
        else if (firstReal > 0 && secondReal > 0 && thirdReal < 0)
        {
            isNegativeSign = true;
        }
        if (firstReal != 0 && secondReal != 0 && thirdReal != 0)
        {
            Console.WriteLine("The product of the three real number has a {0} sign.", isNegativeSign ? "negative (-)" : "positive (+)");
        }
        else
        {
            Console.WriteLine("The product is zero.");
        }
    }
}
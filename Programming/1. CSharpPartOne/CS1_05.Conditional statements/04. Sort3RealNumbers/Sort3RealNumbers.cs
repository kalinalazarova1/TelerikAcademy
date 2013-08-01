//Sort 3 real values in descending order using nested if statements.

using System;

class Sort3RealNumbers
{
    static void Main()
    {
        double firstReal, secondReal, thirdReal;
        double[] result = new double [3];
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
        if (firstReal > secondReal)
        {
            if (firstReal > thirdReal)
            {
                result[0] = firstReal;
                if (secondReal > thirdReal)
                {
                    result[1] = secondReal;
                    result[2] = thirdReal;
                }
                else
                {
                    result[1] = thirdReal;
                    result[2] = secondReal;
                }
            }
            else
            {
                result[0] = thirdReal;
                result[1] = firstReal;
                result[2] = secondReal;
            }
        }
        else
        {
            if (secondReal > thirdReal)
            {
                result[0] = secondReal;
                if (firstReal > thirdReal)
                {
                    result[1] = firstReal;
                    result[2] = thirdReal;
                }
                else
                {
                    result[1] = thirdReal;
                    result[2] = firstReal;
                }
            }
            else
            {
                result[0] = thirdReal;
                result[1] = secondReal;
                result[2] = firstReal;
            }
        }
        Console.WriteLine("Sorted in descending order: ");
        for (int i = 0; i < 3; i++) Console.Write("{0} ", result[i]);
    }
}

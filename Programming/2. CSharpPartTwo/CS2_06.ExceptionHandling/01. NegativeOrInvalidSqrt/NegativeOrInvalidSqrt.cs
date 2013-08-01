//1. Write a program that reads an integer number and calculates and prints its square root. 
//If the number is invalid or negative, print "Invalid number". 
//In all cases finally print "Good bye". Use try-catch-finally.

using System;

class NegativeOrInvalidSqrt
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please input positive integer number");
            uint number = uint.Parse(Console.ReadLine());
            Console.WriteLine("Sqare root of {0} is {1}.", number, Math.Sqrt(number));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        catch(OverflowException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}

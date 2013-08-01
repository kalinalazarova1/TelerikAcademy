//Declare two integer variables assign them with 5 and 10 and then exchange their values

using System;

class ExchangeNumbers
{
    static void Main()
    {
        int firstVar = 5;
        int secondVar = 10;
        Console.WriteLine("Първото число е: {0}, а второто число е: {1}", firstVar, secondVar);
        firstVar = firstVar + secondVar;
        secondVar = firstVar - secondVar;
        firstVar = firstVar - secondVar;
        Console.WriteLine("Първото число е: {0}, а второто число е: {1}", firstVar, secondVar);
    }
}

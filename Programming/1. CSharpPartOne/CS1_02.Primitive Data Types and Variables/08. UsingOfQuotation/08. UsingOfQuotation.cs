//Declare two string variables and assign them with the string: "The "use" of quotations causes difficulties"
//with or without using quoted strings

using System;

class ProgramUsingOfQuotation
{
    static void Main()
    {
        string firstStr = "The \"use\" of quotations causes difficulties.";
        string secondStr = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(firstStr);
        Console.WriteLine(secondStr);
    }
}

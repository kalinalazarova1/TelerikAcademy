using System;

class PrintFirstLastName    //Create a console application that prints your first and last name
{
    static void Main()
    {
        string firstName;
        string lastName;
        Console.WriteLine("Please input your first name:");
        firstName = Console.ReadLine();
        Console.WriteLine("Please input your last name:");
        lastName = Console.ReadLine();
        Console.WriteLine("Your full name is: {0} {1}", firstName, lastName);
    }
}

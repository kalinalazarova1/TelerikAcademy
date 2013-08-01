//A company has a name, address, phone number, fax number, web site and manager. The manager has first name
//last name, age and a phone number. Write a program that reads the information for a company and its manager
//and prints them on the console.

using System;

class CompanyData
{
    static void Main()
    {
        byte managerAge;
        bool isValid;
        Console.WriteLine("Please enter the company name:");
        string companyName = Console.ReadLine();
        Console.WriteLine("Please enter the company address:");
        string companyAddress = Console.ReadLine();
        Console.WriteLine("Please enter the company phone number:");
        string compnayPhone = Console.ReadLine();
        Console.WriteLine("Please enter the company fax number:");
        string companyFax = Console.ReadLine();
        Console.WriteLine("Please enter the company web site:");
        string companyWeb = Console.ReadLine();
        Console.WriteLine("Please enter the first name of the manager:");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine("Please enter the last name of the manager:");
        string managerLastName = Console.ReadLine();
        do
        {
            Console.WriteLine("Please enter the age of the manager:");
            isValid = byte.TryParse(Console.ReadLine(), out managerAge);
        }
        while (!isValid);
        Console.WriteLine("Please enter the phone numnber of the manager:");
        string managerPhone = Console.ReadLine();
        Console.WriteLine("_______________________________________________________________");
        Console.WriteLine("Company: {0}", companyName);
        Console.WriteLine("Address: {0}", companyAddress);
        Console.WriteLine("Phone: {0}, Fax: {1}", compnayPhone, companyFax);
        Console.WriteLine("Web site: {0}", companyWeb);
        Console.WriteLine("Manager: {0} {1}, Age: {2}, Phone number: {3}", managerFirstName, managerLastName, managerAge, managerPhone);
        Console.WriteLine("_______________________________________________________________");
    }
}

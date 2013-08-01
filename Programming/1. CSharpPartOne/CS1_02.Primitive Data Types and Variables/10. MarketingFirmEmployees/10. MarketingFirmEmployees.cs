//Marketing firm keeps record for its employees. Each record shoul have: first name, family name,
//age, gender (m/f), ID number and unique employee number (from 27560000 to 27569999)
//Declare the variables needed to keep the information for a single employee

using System;

class MarketingFirmEmployees
{
    static void Main()
    {
        string firstName = "Ivan";
        string familyName = "Petrov";
        byte age = 28;
        char gender = 'm';
        int idNumber = 1234567890 ;
        int employeeNumber = 27560001;
        Console.WriteLine("{0} {1}, age:{2}, gender:{3}, id:{4}, empolyee number:{5}", firstName, familyName, age, gender      , idNumber, employeeNumber);
    }
}

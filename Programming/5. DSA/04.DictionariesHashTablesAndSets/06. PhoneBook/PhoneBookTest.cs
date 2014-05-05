// 6.* A text file phones.txt holds information about people, their town and phone number:
//
// Mimi Shmatkata          | Plovdiv  | 0888 12 34 56
// Kireto                  | Varna    | 052 23 45 67
// Daniela Ivanova Petrova | Karnobat | 0899 999 888
// Bat Gancho              | Sofia    | 02 946 946 946
//
// Duplicates can occur in people names, towns and phone numbers. Write a program to read the
// phones file and execute a sequence of commands given in the file commands.txt:
// find(name) – display all matching records by given name (first, middle, last or nickname)
// find(name, town) – display all matching records by given name and town

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Program
{
    public static void ExecuteCommand(PhoneBook phonebook, string[] commands)
    {
        if (commands.Length == 3)
        {
            Console.WriteLine(string.Join(Environment.NewLine, phonebook.Find(commands[1])));
            Console.WriteLine("-----------------------------------------------------------");
        }
        else
        {
            Console.WriteLine(string.Join(Environment.NewLine, phonebook.Find(commands[1], commands[2].Trim())));
            Console.WriteLine("-----------------------------------------------------------");
        }
    }

    internal static void Main()
    {
        var myPhoneBook = new PhoneBook();
        var reader = new StreamReader(@"..\..\phonebook.txt");
        var commandReader = new StreamReader(@"..\..\commands.txt");
        string[] separators = { " | " };
        string[] comSeparators = { "(", ")", "," };

        using (reader)
        {
            using (commandReader)
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    myPhoneBook.Add(new PhoneRecord(line.Split(separators, StringSplitOptions.RemoveEmptyEntries)));
                }

                for (string line = commandReader.ReadLine(); line != null; line = commandReader.ReadLine())
                {
                    ExecuteCommand(myPhoneBook, line.Split(comSeparators, StringSplitOptions.RemoveEmptyEntries));
                }
            }
        }
    }
}

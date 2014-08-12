namespace Phonebook
{
    using System;
    using System.Text;

    internal class PhonebookAPI
    {
        internal static void Main()
        {
            var output = new StringBuilder();
            var factory = new PhonebookFactory();
            var commandFactory = factory.GetCommandFactory();
            var phoneBook = factory.GetPhonesRepository();

            var inputLine = Console.ReadLine();
            while (inputLine != "End" && inputLine != null)
            {
                var currentCommand = commandFactory.GetCommand(inputLine);
                output.AppendLine(currentCommand.Execute(phoneBook));
                inputLine = Console.ReadLine();
            }

            Console.Write(output);
        }
    }
}

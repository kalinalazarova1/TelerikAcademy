namespace Phonebook
{
    using System;

    public class CommandFactory : ICommandFactory
    {
        public ICommand GetCommand(string inputLine)
        {
            int openBracketIndex = inputLine.IndexOf('(');
            if (openBracketIndex == -1)
            {
                throw new ArgumentException("Missing symbol ( in the input string.");
            }

            string command = inputLine.Substring(0, openBracketIndex);
            if (!inputLine.EndsWith(")"))
            {
                throw new ArgumentException("The input string have to end with symbol ).");
            }

            string phonesToString = inputLine.Substring(openBracketIndex + 1, inputLine.Length - openBracketIndex - 2);
            string[] phones = phonesToString.Split(',');
            for (int j = 0; j < phones.Length; j++)
            {
                phones[j] = phones[j].Trim();
            }

            if (command == "AddPhone")
            {
                return new AddCommand(phones);
            }
            else if (command == "ChangePhone")
            {
                return new ChangeCommand(phones);
            }
            else if (command == "List")
            {
                return new ListCommand(phones);
            }
            else if(command == "Remove")
            {
                return new RemoveCommand(phones);
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }
        }
    }
}

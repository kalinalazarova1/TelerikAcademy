namespace CalendarSystem
{
    using System;

    public class CommandParser : ICommandParser
    {
        public ICommandInfo Parse(string userLine)
        {
            int firstSpaceIndex = userLine.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + userLine);
            }

            string name = userLine.Substring(0, firstSpaceIndex);
            string argumentsAsString = userLine.Substring(firstSpaceIndex + 1);

            var arguments = argumentsAsString.Split('|');
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            var commandInfo = new CommandInfo(name, arguments);

            return commandInfo;
        }
    }
}

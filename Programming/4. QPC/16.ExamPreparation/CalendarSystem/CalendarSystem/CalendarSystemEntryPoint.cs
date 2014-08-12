namespace CalendarSystem
{
    using System;

    public class CalendarSystemEntryPoint
    {
        internal static void Main()
        {
            var eventManager = new EventsManagerFast();
            var commandParser = new CommandParser();
            var printer = new StringBuilderPrinter();
            var commandFactory = new CommandFactory(eventManager, printer);
            var consolePrinter = new ConsolePrinterVisitor();

            while (true)
            {
                string userLine = Console.ReadLine();
                if (userLine == "End" || userLine == null)
                {
                    break;
                }

                try
                {
                    var commandInfo = commandParser.Parse(userLine);
                    var command = commandFactory.Create(commandInfo);
                    command.Execute(commandInfo.Arguments);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            printer.Accept(consolePrinter);
        }
    }
}

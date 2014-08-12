namespace CalendarSystem
{
    using System;

    public class CommandFactory : ICommandFactory
    {
        private IEventsManager manager;
        private IPrinter printer;

        public CommandFactory(IEventsManager manager, IPrinter printer)
        {
            this.manager = manager;
            this.printer = printer;
        }

        public ICommand Create(ICommandInfo command)
        {
            if (command.Name == "AddEvent" && (command.Arguments.Length == 2 || command.Arguments.Length == 3))
            {
                return new AddCommand(this.manager, this.printer);
            }
            else if (command.Name == "DeleteEvents" && command.Arguments.Length == 1)
            {
                return new DeleteCommand(this.manager, this.printer);
            }
            else if (command.Name == "ListEvents" && command.Arguments.Length == 2)
            {
                return new ListCommand(this.manager, this.printer);
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }
        }
    }
}

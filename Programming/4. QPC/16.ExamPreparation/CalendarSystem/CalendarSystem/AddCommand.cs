namespace CalendarSystem
{
    using System;
    using System.Globalization;

    public class AddCommand : ICommand
    {
        private IEventsManager manager;
        private IPrinter printer;

        public AddCommand(IEventsManager manager, IPrinter printer)
        {
            this.manager = manager;
            this.printer = printer;
        }

        public void Execute(string[] arguments)
        {
            if (arguments.Length == 2)
            {
                var date = DateTime.ParseExact(arguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var entry = new EventEntry
                {
                    Date = date,
                    Title = arguments[1],
                    Location = null,
                };

                this.manager.AddEvent(entry);
                this.printer.Print("Event added");
            }
            else if (arguments.Length == 3)
            {
                var date = new DateTime();
                try
                {
                    date = DateTime.ParseExact(arguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                }
                catch(FormatException)
                {
                    this.printer.Print("Invalid event date.");
                }
                var entry = new EventEntry
                {
                    Date = date,
                    Title = arguments[1],
                    Location = arguments[2],
                };

                this.manager.AddEvent(entry);
                this.printer.Print("Event added");
            }        
        }
    }
}

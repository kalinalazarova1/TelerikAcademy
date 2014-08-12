namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class ListCommand : ICommand
    {
        private IEventsManager manager;
        private IPrinter printer;

        public ListCommand(IEventsManager manager, IPrinter printer)
        {
            this.manager = manager;
            this.printer = printer;
        }

        public void Execute(string[] arguments)
        {
            var date = DateTime.ParseExact(arguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var count = int.Parse(arguments[1]);
            var events = this.manager.ListEvents(date, count);

            if (!events.Any())
            {
                this.printer.Print("No events found");
                return;
            }

            var orderedEvents = events.OrderBy(ev => ev.Date).ThenBy(ev => ev.Title).ThenByDescending(ev => ev.Location);
            this.printer.Print(string.Join(Environment.NewLine, orderedEvents));
        }
    }
}

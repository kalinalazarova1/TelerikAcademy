namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeleteCommand : ICommand
    {
        private IEventsManager manager;
        private IPrinter printer;

        public DeleteCommand(IEventsManager manager, IPrinter printer)
        {
            this.manager = manager;
            this.printer = printer;
        }

        public void Execute(string[] arguments)
        {
            int count = this.manager.DeleteEventsByTitle(arguments[0]);

            if (count == 0)
            {
                this.printer.Print("No events found");
                return;
            }

            this.printer.Print(count + " events deleted");
        }
    }
}

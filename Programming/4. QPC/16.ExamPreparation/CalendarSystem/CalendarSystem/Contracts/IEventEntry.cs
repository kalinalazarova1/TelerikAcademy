namespace CalendarSystem
{
    using System;

    public interface IEventEntry
    {
        DateTime Date { get; set; }

        string Title { get; set; }

        string Location { get; set; }
    }
}

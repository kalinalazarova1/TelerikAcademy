namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;

    public interface IEventsManager
    {
        void AddEvent(EventEntry entry);

        int DeleteEventsByTitle(string title);

        IEnumerable<EventEntry> ListEvents(DateTime date, int count);
    }
}

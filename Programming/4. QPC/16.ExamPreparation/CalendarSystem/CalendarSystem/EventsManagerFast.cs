namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MultiDictionary = Wintellect.PowerCollections.MultiDictionary<string, CalendarSystem.EventEntry>;
    using OrderedMultiDictionary = Wintellect.PowerCollections.OrderedMultiDictionary<System.DateTime, EventEntry>;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary eventsKeyLowerTitle;
        private readonly OrderedMultiDictionary orderedByDateEvents;

        public EventsManagerFast()
        {
            this.eventsKeyLowerTitle = new MultiDictionary(true);
            this.orderedByDateEvents = new OrderedMultiDictionary(true);
        }

        public void AddEvent(EventEntry entry)
        {
            string eventTitleLowerCase = entry.Title.ToLowerInvariant();
            this.eventsKeyLowerTitle.Add(eventTitleLowerCase, entry);
            this.orderedByDateEvents.Add(entry.Date, entry);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleToLower = title.ToLowerInvariant();
            var eventsForDelete = this.eventsKeyLowerTitle[titleToLower];
            int countForDelete = eventsForDelete.Count;

            foreach (var entry in eventsForDelete)
            {
                this.orderedByDateEvents.Remove(entry.Date, entry);
            }

            this.eventsKeyLowerTitle.Remove(titleToLower);

            return countForDelete;
        }

        public IEnumerable<EventEntry> ListEvents(DateTime date, int count)
        {
            var allEventsOnDate = this.orderedByDateEvents.RangeFrom(date, true).Values;
            var events = allEventsOnDate.Take(count);
            return events;
        }
    }
}

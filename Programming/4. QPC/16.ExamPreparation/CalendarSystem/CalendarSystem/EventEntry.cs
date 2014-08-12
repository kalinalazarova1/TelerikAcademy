namespace CalendarSystem
{
    using System;

    public class EventEntry : IComparable<EventEntry>, IEventEntry
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(EventEntry entry)
        {
            int result = DateTime.Compare(this.Date, entry.Date);
            if (result == 0)
            {
                result = string.Compare(this.Title, entry.Title, StringComparison.Ordinal);
            }

            if (result == 0)
            {
                result = string.Compare(this.Location, entry.Location, StringComparison.Ordinal);
            }

            return result;
        }
    }
}

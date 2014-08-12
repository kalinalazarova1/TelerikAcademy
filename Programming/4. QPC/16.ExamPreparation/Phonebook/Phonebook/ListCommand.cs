namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListCommand : Command
    {
        private const string InvalidRangeString = "Invalid range";
        private string[] entry;

        public ListCommand(string[] entry)
        {
            this.entry = entry;
        }

        public override string Execute(IRemovablePhonebookRepository phoneBook)
        {
            try
            {
                var startIndex = int.Parse(this.entry[0]);
                var count = int.Parse(this.entry[1]);
                IEnumerable<IPhonebookEntry> listedEntries = phoneBook.ListEntries(startIndex, count);

                return string.Join(Environment.NewLine, listedEntries);
            }
            catch (ArgumentOutOfRangeException)
            {
                return ListCommand.InvalidRangeString;
            }
        }
    }
}

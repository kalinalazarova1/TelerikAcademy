namespace Phonebook
{
    using System.Collections.Generic;

    public class PhonebookRepository : IRemovablePhonebookRepository
    {
        private IRemovabaleDatabase database;

        public PhonebookRepository() : this(new PhoneDatabase())
        {
        }

        public PhonebookRepository(IRemovabaleDatabase phoneDatabase)
        {
            this.database = phoneDatabase;
        }

        public bool AddPhone(string name, IEnumerable<string> numbers)
        {
            return this.database.Add(name, numbers);
        }

        public int ChangePhone(string oldEntry, string newEntry)
        {
            return this.database.Change(oldEntry, newEntry);
        }

        public int RemovePhone(string number)
        {
            return this.database.Remove(number);
        }

        public IEnumerable<IPhonebookEntry> ListEntries(int start, int count)
        {
            return this.database.ListEntries(start, count);
        }
    }
}

namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhoneDatabase : IRemovabaleDatabase
    {
        private OrderedSet<IPhonebookEntry> sortedByNamePhoneEntries;
        private Dictionary<string, IPhonebookEntry> phoneBookNameKey;
        private MultiDictionary<string, IPhonebookEntry> phoneBookNumberKey;

        public PhoneDatabase()
        {
            this.sortedByNamePhoneEntries = new OrderedSet<IPhonebookEntry>();
            this.phoneBookNameKey = new Dictionary<string, IPhonebookEntry>();
            this.phoneBookNumberKey = new MultiDictionary<string, IPhonebookEntry>(false);
        }

        public bool Add(string name, IEnumerable<string> phoneNumbers)
        {
            string nameToLower = name.ToLowerInvariant();
            IPhonebookEntry entry;
            bool entryExists = this.phoneBookNameKey.TryGetValue(nameToLower, out entry);
            if (!entryExists)
            {
                entry = new PhonebookEntry();
                entry.Name = name;
                entry.PhoneNumbers = new SortedSet<string>();
                this.phoneBookNameKey.Add(nameToLower, entry);
                this.sortedByNamePhoneEntries.Add(entry);
            }

            foreach (var number in phoneNumbers)
            {
                this.phoneBookNumberKey.Add(number, entry);
            }

            entry.PhoneNumbers.UnionWith(phoneNumbers);
            return entryExists;
        }

        public int Change(string oldEntry, string newEntry)
        {
            var foundEntries = this.phoneBookNumberKey[oldEntry].ToList();
            foreach (var entry in foundEntries)
            {
                entry.PhoneNumbers.Remove(oldEntry);
                this.phoneBookNumberKey.Remove(oldEntry, entry);
                entry.PhoneNumbers.Add(newEntry);
                this.phoneBookNumberKey.Add(newEntry, entry);
            }

            return foundEntries.Count;
        }

        public int Remove(string number)
        {
            var foundEntries = this.phoneBookNumberKey[number].ToList();
            
            foreach (var entry in foundEntries)
            {
                entry.PhoneNumbers.Remove(number);
                if (entry.PhoneNumbers.Count() == 0)
                {
                    this.sortedByNamePhoneEntries.Remove(entry);
                    this.phoneBookNameKey.Remove(entry.Name.ToLower());
                }
                this.phoneBookNumberKey.Remove(number, entry);
            }

            return foundEntries.Count;
        }

        public IEnumerable<IPhonebookEntry> ListEntries(int start, int count)
        {
            if (start < 0 || start + count > this.phoneBookNameKey.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            IPhonebookEntry[] listedEntries = new PhonebookEntry[count];
            for (int i = start; i <= start + count - 1; i++)
            {
                IPhonebookEntry entry = this.sortedByNamePhoneEntries[i];
                listedEntries[i - start] = entry;
            }

            return listedEntries;
        }
    }
}

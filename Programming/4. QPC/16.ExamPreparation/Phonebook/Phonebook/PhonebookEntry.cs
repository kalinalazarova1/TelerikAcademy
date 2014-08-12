namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<IPhonebookEntry>, IPhonebookEntry
    {
        private string name;
        private string nameToLower;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.nameToLower = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhoneNumbers { get; set; }

        public override string ToString()
        {
            var entryToString = new StringBuilder();
            entryToString.Append('[');
            entryToString.Append(this.Name);
            entryToString.Append(": ");
            entryToString.Append(string.Join(", ", this.PhoneNumbers));
            entryToString.Append(']');
            return entryToString.ToString();
        }

        public int CompareTo(IPhonebookEntry other)
        {
            return this.nameToLower.CompareTo(other.Name.ToLower());
        }
    }
}

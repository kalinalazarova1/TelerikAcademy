namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public interface IPhonebookEntry : IComparable<IPhonebookEntry>
    {
        string Name { get; set; }

        SortedSet<string> PhoneNumbers { get; set; }
    }
}

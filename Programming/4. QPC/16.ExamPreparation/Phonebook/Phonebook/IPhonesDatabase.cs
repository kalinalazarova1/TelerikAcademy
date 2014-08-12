namespace Phonebook
{
    using System.Collections.Generic;

    public interface IPhonesDatabase
    {
        bool Add(string name, IEnumerable<string> phoneNumbers);

        int Change(string oldPhoneNumber, string newPhoneNumber);

        IEnumerable<IPhonebookEntry> ListEntries(int startIndex, int count);
    }
}

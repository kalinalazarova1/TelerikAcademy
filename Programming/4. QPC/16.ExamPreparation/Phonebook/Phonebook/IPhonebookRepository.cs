namespace Phonebook
{
    using System.Collections.Generic;

    public interface IPhonebookRespoitory
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        IEnumerable<IPhonebookEntry> ListEntries(int startIndex, int count);
    }
}

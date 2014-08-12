namespace Phonebook
{
    using System.Linq;
    using System.Text;

    public class AddCommand : Command
    {
        private const string EntryCreated = "Phone entry created";
        private const string EntryMerged = "Phone entry merged";

        private string[] entry;

        public AddCommand(string[] entry)
        {
            this.entry = entry;
        }

        public override string Execute(IRemovablePhonebookRepository phoneBook)
        {
            var entryName = this.entry[0];
            var entryPhones = this.entry.Skip(1).ToList();
            for (int i = 0; i < entryPhones.Count; i++)
            {
                entryPhones[i] = this.NormalizePhoneNumber(entryPhones[i]);
            }

            bool isNewEntry = phoneBook.AddPhone(entryName, entryPhones);
            if (isNewEntry)
            {
                return AddCommand.EntryCreated;
            }
            else
            {
                return AddCommand.EntryMerged;
            }
        }   
    }
}

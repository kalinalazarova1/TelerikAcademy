namespace Phonebook
{
    public class ChangeCommand : Command
    {
        private string[] entry;

        public ChangeCommand(string[] entry)
        {
            this.entry = entry;
        }

        public override string Execute(IRemovablePhonebookRepository phoneBook)
        {
            var oldPhoneNumber = NormalizePhoneNumber(this.entry[0]);
            var changedPhoneNumber = NormalizePhoneNumber(this.entry[1]);
            var changedNumbersCount = phoneBook.ChangePhone(oldPhoneNumber, changedPhoneNumber);
            return changedNumbersCount + " numbers changed";
        }
    }
}

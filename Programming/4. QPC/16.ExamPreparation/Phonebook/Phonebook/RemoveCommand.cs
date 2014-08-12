namespace Phonebook
{
    public class RemoveCommand : Command
    {
        private string[] entry;

        public RemoveCommand(string[] entry)
        {
            this.entry = entry;
        }

        public override string Execute(IRemovablePhonebookRepository phoneBook)
        {
            var phoneNumber = NormalizePhoneNumber(this.entry[0]);
            var removedNumbersCount = phoneBook.RemovePhone(phoneNumber);
            return removedNumbersCount + " numbers removed";
        }
    }
}

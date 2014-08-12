namespace Phonebook
{
    public interface IRemovablePhonebookRepository : IPhonebookRespoitory
    {
        int RemovePhone(string number);
    }
}

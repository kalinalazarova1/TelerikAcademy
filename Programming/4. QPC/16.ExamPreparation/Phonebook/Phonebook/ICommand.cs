namespace Phonebook
{
    public interface ICommand
    {
        string Execute(IRemovablePhonebookRepository repository);
    }
}

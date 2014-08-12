namespace Phonebook
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string inputLine);
    }
}

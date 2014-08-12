namespace Phonebook
{
    public interface IPhonebookFactory
    {
        ICommandFactory GetCommandFactory();
        
        IPhonesDatabase GetPhonesDatabase();

        IPhonebookRespoitory GetPhonesRepository();
    }
}

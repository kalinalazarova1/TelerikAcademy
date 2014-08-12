namespace CalendarSystem
{
    public interface ICommandFactory
    {
        ICommand Create(ICommandInfo command);
    }
}

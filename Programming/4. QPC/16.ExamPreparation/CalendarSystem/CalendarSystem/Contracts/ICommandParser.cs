namespace CalendarSystem
{
    public interface ICommandParser
    {
        ICommandInfo Parse(string userLine);
    }
}

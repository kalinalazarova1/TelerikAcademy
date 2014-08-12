namespace CalendarSystem
{
    public interface ICommandInfo
    {
        string Name { get; set; }

        string[] Arguments { get; set; }
    }
}

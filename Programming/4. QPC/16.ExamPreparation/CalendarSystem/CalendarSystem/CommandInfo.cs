namespace CalendarSystem
{
    public class CommandInfo : ICommandInfo
    {
        public CommandInfo(string name, string[] arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }

        public string Name { get; set; }

        public string[] Arguments { get; set; }
    }
}

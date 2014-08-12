namespace ComputersBuilder
{
    using System;
    using System.Text;

    public interface IColorStringBuilder
    {
        ConsoleColor Color { get; }

        StringBuilder Output { get; }
    }
}

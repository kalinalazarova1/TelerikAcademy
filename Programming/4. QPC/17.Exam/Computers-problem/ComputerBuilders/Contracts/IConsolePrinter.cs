namespace ComputersBuilder
{
    using System.Collections.Generic;

    public interface IConsolePrinter
    {
        void Print(IList<IColorStringBuilder> list);
    }
}

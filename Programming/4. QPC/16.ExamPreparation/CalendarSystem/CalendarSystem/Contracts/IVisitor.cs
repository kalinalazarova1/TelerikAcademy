namespace CalendarSystem
{
    using System.Text;

    public interface IVisitor
    {
        void Visit(StringBuilder text);
    }
}

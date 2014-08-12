namespace CalendarSystem
{
    public interface IPrinter
    {
        void Print(string text);

        void Accept(IVisitor visitor);
    }
}

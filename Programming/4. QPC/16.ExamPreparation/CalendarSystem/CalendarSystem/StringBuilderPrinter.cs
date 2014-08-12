namespace CalendarSystem
{
    using System.Text;

    public class StringBuilderPrinter : IPrinter
    {
        private StringBuilder conatiner;

        public StringBuilderPrinter()
        {
            this.conatiner = new StringBuilder();
        }

        public void Print(string text)
        {
            this.conatiner.AppendLine(text);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this.conatiner);
        }
    }
}

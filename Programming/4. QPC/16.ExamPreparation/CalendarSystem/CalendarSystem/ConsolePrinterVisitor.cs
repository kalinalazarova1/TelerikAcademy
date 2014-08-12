namespace CalendarSystem
{
    using System;
    using System.Text;

    public class ConsolePrinterVisitor : IVisitor
    {
        public void Visit(StringBuilder text)
        {
            Console.Write(text.ToString());
        }
    }
}

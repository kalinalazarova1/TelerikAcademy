namespace ComputersBuilder.Console.UI
{
    using System;
    using System.Collections.Generic;

    public class ConsolePrinter : IConsolePrinter
    {
        public void Print(IList<IColorStringBuilder> list)
        {
            foreach (var colorText in list)
            {
                Console.ForegroundColor = colorText.Color;
                Console.WriteLine(colorText.Output);
                Console.ResetColor();
            }
        }
    }
}

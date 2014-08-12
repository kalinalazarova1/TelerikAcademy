namespace ComputersBuilder
{
    using System;
    using System.Text;

    public struct ColorStringBuilder : IColorStringBuilder
    {
        private ConsoleColor color;
        private StringBuilder output;

        public ColorStringBuilder(ConsoleColor color, string text)
        {
            this.color = color;
            this.output = new StringBuilder(text);
        }

        public ConsoleColor Color 
        {
            get
            {
                return this.color;
            }
        }

        public StringBuilder Output
        {
            get
            {
                return this.output;
            }
        }
    }
}

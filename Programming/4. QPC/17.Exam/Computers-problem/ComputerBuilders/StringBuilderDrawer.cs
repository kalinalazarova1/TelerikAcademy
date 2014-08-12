namespace ComputersBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StringBuilderDrawer : IStringBuilderDrawer
    {
        private List<IColorStringBuilder> output;

        public StringBuilderDrawer()
        {
            this.output = new List<IColorStringBuilder>();
        }

        public IList<IColorStringBuilder> GetAllOutput() 
        {
            return this.output;
        }

        public void Draw(IColorStringBuilder text)
        {
            if (this.output.Count > 0 && this.output[this.output.Count - 1].Color == text.Color)
            {
                this.output[this.output.Count - 1].Output.Append("\n");
                this.output[this.output.Count - 1].Output.Append(text.Output);
            }
            else
            {
                this.output.Add(text);
            }
        }
    }
}

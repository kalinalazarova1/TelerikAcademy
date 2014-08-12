namespace ComputersBuilder
{
    using System.Collections.Generic;

    public interface IStringBuilderDrawer
    {
        IList<IColorStringBuilder> GetAllOutput();

        void Draw(IColorStringBuilder text);
    }
}

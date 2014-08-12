namespace ComputersBuilder
{
    using System;

    public class MonochromeVideoCard : VideoCard, IVideoCard
    {
        public MonochromeVideoCard(IStringBuilderDrawer drawer)
            : base(drawer)
        {
        }

        public override void Draw(string text)
        {
            this.Drawer.Draw(new ColorStringBuilder(ConsoleColor.Gray, text));
        }
    }
}

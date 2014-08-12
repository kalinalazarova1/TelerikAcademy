namespace ComputersBuilder
{
    using System;

    public class ColorfulVideoCard : VideoCard, IVideoCard
    {
        public ColorfulVideoCard(IStringBuilderDrawer drawer)
            : base(drawer)
        {
        }

        public override void Draw(string text)
        {
            this.Drawer.Draw(new ColorStringBuilder(ConsoleColor.Green, text));
        }
    }
}

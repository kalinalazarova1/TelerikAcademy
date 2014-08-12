namespace ComputersBuilder
{
    using System;

    public abstract class VideoCard
    {
        public VideoCard(IStringBuilderDrawer drawer)
        {
            this.Drawer = drawer;
        }

        protected IStringBuilderDrawer Drawer { get; set; }

        public abstract void Draw(string text);
    }
}

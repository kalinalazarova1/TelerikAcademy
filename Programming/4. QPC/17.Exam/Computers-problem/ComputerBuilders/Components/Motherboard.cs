namespace ComputersBuilder
{
    public class Motherboard : IMotherboard
    {
        private IRam ram;
        private IVideoCard videoCard;

        public Motherboard(IVideoCard videoCard, IRam ram)
        {
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public int LoadRamValue()
        {
            return this.ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.videoCard.Draw(data);
        }
    }
}

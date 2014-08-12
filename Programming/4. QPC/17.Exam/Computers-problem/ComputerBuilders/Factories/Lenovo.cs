namespace ComputersBuilder
{
    using System.Collections.Generic;

    public class Lenovo : IManufacturer
    {
        private IComputerFactory factory;
        private IStringBuilderDrawer drawer;

        public Lenovo(IComputerFactory factory, IStringBuilderDrawer drawer)
        {
            this.factory = factory;
            this.drawer = drawer;
        }

        public IServer GetServer()
        {
            var ram = new Ram(8);
            var videoCard = new MonochromeVideoCard(this.drawer);
            var motherboard = new Motherboard(videoCard, ram);
            return this.factory.GetServer(
                new Cpu128(4),
                new List<IHardDrive>
                    {
                        new HardDrive(0, 2)
                    },
                motherboard);
        }

        public IPc GetPc()
        {
            var ram = new Ram(4);
            var videoCard = new MonochromeVideoCard(this.drawer);
            var motherboard = new Motherboard(videoCard, ram);
            return this.factory.GetPc(
                    new Cpu64(2),
                    new[] { new HardDrive(500, 0) },
                    motherboard);
        }

        public ILaptop GetLaptop()
        {
            var videoCard = new ColorfulVideoCard(this.drawer);
            var ram = new Ram(4);
            var motherboard = new Motherboard(videoCard, ram);
            return this.factory.GetLaptop(
                new Cpu64(2),
                new[] { new HardDrive(500, 0) },
                motherboard,
                new LaptopBattery());
        }
    }
}

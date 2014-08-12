namespace ComputersBuilder
{
    using System.Collections.Generic;

    public class Dell : IManufacturer
    {
        private IComputerFactory factory;
        private IStringBuilderDrawer drawer;

        public Dell(IComputerFactory factory, IStringBuilderDrawer drawer)
        {
            this.factory = factory;
            this.drawer = drawer;
        }

        public IServer GetServer()
        {
            var ram = new Ram(64);
            var videoCard = new MonochromeVideoCard(this.drawer);
            var motherboard = new Motherboard(videoCard, ram);
            return this.factory.GetServer(
                new Cpu64(8),
                new List<IHardDrive>
                    {
                    new Raid(0, 2, new List<IHardDrive> { new HardDrive(2000, 0), new HardDrive(2000, 0) })
                    },
                motherboard);
        }

        public IPc GetPc()
        {
            var ram = new Ram(8);
            var videoCard = new ColorfulVideoCard(this.drawer);
            var motherboard = new Motherboard(videoCard, ram);
            return this.factory.GetPc(
                    new Cpu64(4),
                    new[] { new HardDrive(1000, 0) },
                    motherboard);
        }

        public ILaptop GetLaptop()
        {
            var ram = new Ram(8);
            var videoCard = new ColorfulVideoCard(this.drawer);
            var motherboard = new Motherboard(videoCard, ram);
                return this.factory.GetLaptop(
                    new Cpu32(8),
                    new[] { new HardDrive(1000, 0) },
                    motherboard,
                    new LaptopBattery());
        }
    }
}

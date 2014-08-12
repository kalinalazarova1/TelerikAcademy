namespace ComputersBuilder
{
    using System.Collections.Generic;

    public class Hp : IManufacturer
    {
        private IComputerFactory factory;
        private IStringBuilderDrawer drawer;

        public Hp(IComputerFactory factory, IStringBuilderDrawer drawer)
        {
            this.factory = factory;
            this.drawer = drawer;
        }

        public IServer GetServer()
        {
            var ram = new Ram(32);
            var videoCard = new MonochromeVideoCard(this.drawer);
            var motherboard = new Motherboard(videoCard, ram);
            return this.factory.GetServer(
                new Cpu32(4),
                new List<IHardDrive>
                    {
                        new Raid(0, 2, new List<IHardDrive> { new HardDrive(1000, 0), new HardDrive(1000, 0) })
                    },
                motherboard);
        }

        public IPc GetPc()
        {
            var ram = new Ram(2);
            var videoCard = new ColorfulVideoCard(this.drawer);
            var motherboard = new Motherboard(videoCard, ram);
            return this.factory.GetPc(
                    new Cpu32(2),
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
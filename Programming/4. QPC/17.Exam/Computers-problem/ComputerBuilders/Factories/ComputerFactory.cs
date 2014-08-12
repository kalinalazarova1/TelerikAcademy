namespace ComputersBuilder
{
    using System.Collections.Generic;

    public class ComputerFactory : IComputerFactory
    {
        public ILaptop GetLaptop(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard,
            ILaptopBattery battery)
        {
                return new Laptop(cpu, hardDrives, motherboard, battery);
        }
           
        public IPc GetPc(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard)
        {
                return new Pc(cpu, hardDrives, motherboard);
        }

        public IServer GetServer(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard)
        {
                return new Server(cpu, hardDrives, motherboard);
        }
    }
}

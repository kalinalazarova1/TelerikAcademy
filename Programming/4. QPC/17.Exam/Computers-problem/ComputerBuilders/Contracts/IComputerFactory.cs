namespace ComputersBuilder
{
    using System.Collections.Generic;

    public interface IComputerFactory
    {
        ILaptop GetLaptop(
             ICpu cpu,
             IEnumerable<IHardDrive> hardDrives,
             IMotherboard motherboard,
             ILaptopBattery battery);

        IPc GetPc(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard);

        IServer GetServer(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard);
    }
}

namespace ComputersBuilder
{
    using System.Collections.Generic;

    public interface IComputer
    {
        IEnumerable<IHardDrive> HardDrives { get; set; }

        ICpu Cpu { get; set; }

        IMotherboard Motherboard { get; }
    }
}

namespace ComputersBuilder
{
    using System;
    using System.Collections.Generic;

    public abstract class Computer : IComputer
    {
        public Computer(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard)
        {
            this.Cpu = cpu;
            this.HardDrives = hardDrives;
            this.Motherboard = motherboard;
        }

        public IEnumerable<IHardDrive> HardDrives { get; set; }

        public ICpu Cpu { get; set; }

        public IMotherboard Motherboard { get; private set; }
    }
}

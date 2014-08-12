namespace ComputersBuilder
{
    using System.Collections.Generic;

    public class Server : Computer, IComputer, IServer
    {
        public Server(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard)
            : base(cpu, hardDrives, motherboard)
        {
        }

        public void Process(int data)
        {
            this.Motherboard.SaveRamValue(data);
            this.Motherboard.DrawOnVideoCard(Cpu.SquareNumber(data));
        }
    }
}

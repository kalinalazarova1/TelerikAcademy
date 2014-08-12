namespace ComputersBuilder
{
    using System.Collections.Generic;

    public class Laptop : Computer, IComputer, ILaptop
    {
        public Laptop(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard,
            ILaptopBattery battery)
            : base(cpu, hardDrives, motherboard)
        {
            this.Battery = battery;
        }

        public ILaptopBattery Battery { get; private set; }

        public void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.Motherboard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.Battery.ChargePercentage));
        }
    }
}

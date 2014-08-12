namespace ComputersBuilder
{
    using System.Collections.Generic;

    public class Pc : Computer, IComputer, IPc
    {
        public Pc(
            ICpu cpu,
            IEnumerable<IHardDrive> hardDrives,
            IMotherboard motherboard)
            : base(cpu, hardDrives, motherboard)
        {
        }

        public void Play(int guessNumber)
        {
            Cpu.RandomInRange(1, 10);
            var savedNumber = this.Motherboard.LoadRamValue();
            if (savedNumber != guessNumber)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", savedNumber));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}

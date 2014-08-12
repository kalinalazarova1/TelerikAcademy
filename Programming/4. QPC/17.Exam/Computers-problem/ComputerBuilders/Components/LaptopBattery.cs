namespace ComputersBuilder
{
    public class LaptopBattery : ILaptopBattery
    {
        private const int MaxCapacity = 100;
        private const int MinCapacity = 0;

        public LaptopBattery() 
        {
            this.ChargePercentage = LaptopBattery.MaxCapacity / 2; 
        }

        public int ChargePercentage { get; set; }

        public void Charge(int p)
        {
            this.ChargePercentage += p;
            if (this.ChargePercentage > LaptopBattery.MaxCapacity)
            {
                this.ChargePercentage = LaptopBattery.MaxCapacity;
            }

            if (this.ChargePercentage < LaptopBattery.MinCapacity)
            {
                this.ChargePercentage = LaptopBattery.MinCapacity;
            }
        }
    }
}

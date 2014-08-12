namespace ComputersBuilder
{
    public interface ILaptopBattery
    {
        int ChargePercentage { get; set; }

        void Charge(int percentage);
    }
}

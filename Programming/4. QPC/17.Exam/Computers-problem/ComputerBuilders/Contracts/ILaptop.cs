namespace ComputersBuilder
{
    public interface ILaptop
    {
        ILaptopBattery Battery { get; }

        void ChargeBattery(int percentage);
    }
}

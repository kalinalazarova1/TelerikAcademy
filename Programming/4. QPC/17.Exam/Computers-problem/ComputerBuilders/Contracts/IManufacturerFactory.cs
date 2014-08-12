namespace ComputersBuilder
{
    public interface IManufacturerFactory
    {
        IManufacturer GetManufacturer(string name);
    }
}

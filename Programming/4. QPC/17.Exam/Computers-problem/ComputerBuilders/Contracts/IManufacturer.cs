namespace ComputersBuilder
{
    public interface IManufacturer
    {
        IServer GetServer();

        IPc GetPc();

        ILaptop GetLaptop();
    }
}

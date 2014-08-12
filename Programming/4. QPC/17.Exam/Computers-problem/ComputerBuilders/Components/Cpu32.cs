namespace ComputersBuilder
{
    public class Cpu32 : Cpu, ICpu
    {
        private const int MaxNumber = 500;

        public Cpu32(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int GetLimit()
        {
            return Cpu32.MaxNumber;
        }
    }
}

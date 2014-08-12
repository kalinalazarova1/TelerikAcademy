namespace ComputersBuilder
{
    public class Cpu128 : Cpu, ICpu
    {
        private const int MaxNumber = 2000;

        public Cpu128(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int GetLimit()
        {
            return Cpu128.MaxNumber;
        }
    }
}

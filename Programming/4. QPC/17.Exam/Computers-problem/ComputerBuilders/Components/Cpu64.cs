namespace ComputersBuilder
{
    public class Cpu64 : Cpu, ICpu
    {
        private const int MaxNumber = 1000;

        public Cpu64(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int GetLimit()
        {
            return Cpu64.MaxNumber;
        }
    }
}

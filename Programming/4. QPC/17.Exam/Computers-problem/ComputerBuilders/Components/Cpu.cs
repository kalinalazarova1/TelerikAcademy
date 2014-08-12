namespace ComputersBuilder
{
    using System;

    public abstract class Cpu : ICpu
    {
        private static readonly Random Random = new Random();

        public Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; set; }

        public int RandomInRange(int min, int max)
        {
            int randomNumber = Random.Next(min, max + 1);
            return randomNumber;
        }

        public string SquareNumber(int data)
        {
            var limit = GetLimit();
            if (data < 0)
            {
                return "Number too low.";
            }
            else if (data > limit)
            {
                return "Number too high.";
            }
            else
            {
                return string.Format("Square of {0} is {1}.", data, data * data);
            }
        }

        public abstract int GetLimit();
    }
}

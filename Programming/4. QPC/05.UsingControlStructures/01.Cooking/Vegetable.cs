namespace _01.Cooking
{
    using System;

    public abstract class Vegetable
    {
        public Vegetable(VegiType type)
        {
            this.Type = type;
            this.IsPeeled = false;
            this.IsCut = false;
            this.IsRotten = false;
        }

        public VegiType Type { get; private set; }

        public bool IsPeeled { get; private set; }

        public bool IsCut { get; private set; }

        public bool IsRotten { get; set; }

        public void Peel() 
        {
            this.IsPeeled = true;
            Console.WriteLine("{0} is peeled!", this.Type);
        }

        public void Cut()
        {
            this.IsCut = true;
            Console.WriteLine("{0} is cut!", this.Type);
        }
    }
}
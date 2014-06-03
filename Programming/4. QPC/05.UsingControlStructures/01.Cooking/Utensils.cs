namespace _01.Cooking
{
    using System.Collections.Generic;

    public abstract class Utensils
    {
        public Utensils(UtensilType type)
        {
            this.Type = type;
            this.Content = new List<Vegetable>();
        }

        public IList<Vegetable> Content { get; private set; }

        public UtensilType Type { get; private set; } 

        public void Add(Vegetable vegitable)
        {
            this.Content.Add(vegitable);
            System.Console.WriteLine("{0} is added to {1}!", vegitable.Type, this.Type);
        }
    }
}

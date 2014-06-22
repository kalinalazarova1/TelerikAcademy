namespace _01.KnapsackProblem
{
    public class Product
    {
        public Product(string name, double weight, double price)
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public override string ToString()
        {
            return this.Name + " - weight=" + this.Weight + ", cost=" + this.Price;
        }
    }
}

namespace _05.ShoppingCenter
{
    using System;

    public class Product : IEquatable<Product>
    {
        public Product(string name, string producer, decimal price = 0.00m)
        {
            this.Name = name;
            this.Producer = producer;
            this.Price = price;
        }

        public string Name { get; set; }

        public string Producer { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }

        public bool Equals(Product other)
        {
            return this.Name == other.Name && this.Producer == other.Producer && this.Price == other.Price;
        }
    }
}

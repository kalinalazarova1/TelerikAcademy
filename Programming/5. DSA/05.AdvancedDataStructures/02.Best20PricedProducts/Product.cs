using System;

public class Product : IComparable
{
    private decimal price;

    public Product(string name, decimal price)
    {
        this.Price = price;
        this.Name = name;
    }

    public string Name { get; set; }

    public decimal Price 
    {
        get
        {
            return this.price;
        }

        set
        {
            if (value > 0)
            {
                this.price = value;
            }
            else
            {
                throw new ArgumentException("The price could not be negative or zero!");
            }
        }
    }

    public int CompareTo(object obj)
    {
        var other = obj as Product;
        if (other == null)
        {
            throw new ArgumentNullException();
        }

        return this.Price.CompareTo(other.Price);
    }
}

namespace _05.ShoppingCenter
{
    using System.Collections.Generic;

    public class PriceComaparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}

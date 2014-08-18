namespace _05.ShoppingCenter
{
    using System.Collections.Generic;

    public class ProducerComaparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Producer.CompareTo(y.Producer);
        }
    }
}

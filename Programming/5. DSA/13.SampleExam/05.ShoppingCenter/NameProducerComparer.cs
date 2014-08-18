namespace _05.ShoppingCenter
{
    using System.Collections.Generic;

    public class NameProducerComaparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x.Name.CompareTo(y.Name) == 0)
            {
                return x.Producer.CompareTo(y.Producer);
            }

            return x.Name.CompareTo(y.Name);
        }
    }
}
namespace _05.ShoppingCenter
{
    using System.Collections.Generic;

    public class NameComaparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}

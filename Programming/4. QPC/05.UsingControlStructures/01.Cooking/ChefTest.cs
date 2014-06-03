// 1. Refactor the following class using best practices for organizing straight-line code:

namespace _01.Cooking
{
    using System;
    using System.Collections.Generic;

    public static class ChefTest
    {
        public static void Main(string[] args)
        {
            var products = new List<Vegetable>();
            products.Add(new Potato());
            products.Add(new Carrot());

            Chef pierre = new Chef("Pierre");
            pierre.CookVegitables(products, new Bowl());
        }
    }
}

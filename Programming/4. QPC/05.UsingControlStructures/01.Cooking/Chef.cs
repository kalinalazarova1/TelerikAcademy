namespace _01.Cooking
{
    using System;
    using System.Collections.Generic;

    public class Chef
    {
        public Chef(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void CookVegitables(IList<Vegetable> vegitables, Utensils cookingUtensil)
        {
            foreach (var vegi in vegitables)
            {
                vegi.Peel();
                vegi.Cut();
                cookingUtensil.Add(vegi);
            }

            Console.WriteLine("Chef {0} cooked the vegitables!!!", this.Name);
        }
    }
}

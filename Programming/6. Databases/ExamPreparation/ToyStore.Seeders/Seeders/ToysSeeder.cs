namespace ToyStore.Seeder
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using ToyStore.Models;

    public class ToysSeeder : ToyStoreSeeder, IToyStoreSeeder
    {
        public ToysSeeder(ToyStoreEntities db, IRandomDataGenerator ran, int count)
            : base(db, ran, count)
        {
        }

        public override void Seed()
        {
            var ageRangesIds = this.Database.AgeRanges.Select(a => a.Id).ToList();
            var manufacturerIds = this.Database.Manufacturers.Select(m => m.Id).ToList();
            var categoriesIds = this.Database.Categories.Select(c => c.Id).ToList();
            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy()
                {
                    Name = this.Random.GetString(3, 50),
                    Type = this.Random.GetChance(5) ? null : this.Random.GetString(3, 30),
                    AgeRangeId = ageRangesIds[this.Random.GetInt(0, ageRangesIds.Count - 1)],
                    Color = this.Random.GetChance(5) ? null : this.Random.GetString(3, 15),
                    Price = (decimal)this.Random.GetDouble(),
                    ManufacturerId = manufacturerIds[this.Random.GetInt(0, manufacturerIds.Count - 1)]
                };

                var maxCategories = this.Random.GetInt(0, (int)Math.Min(10, categoriesIds.Count));
                if (maxCategories > 0)
                {
                    var uniqueCategories = new HashSet<int>();
                    while (uniqueCategories.Count < maxCategories)
                    {
                        var categoryId = categoriesIds[this.Random.GetInt(0, categoriesIds.Count - 1)];
                        uniqueCategories.Add(categoryId);
                    }

                    foreach (var categoryId in uniqueCategories)
                    {
                        toy.Categories.Add(this.Database.Categories.Find(categoryId));
                    }
                }

                this.Database.Toys.Add(toy);
                if (i % 100 == 0)
                {
                    this.Database.SaveChanges();
                    //// Console.Write(".");
                }
            }

            this.Database.SaveChanges();
        }
    }
}

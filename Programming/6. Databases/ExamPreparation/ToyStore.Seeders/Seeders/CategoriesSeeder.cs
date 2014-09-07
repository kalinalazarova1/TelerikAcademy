namespace ToyStore.Seeder
{
    using System.Collections.Generic;
    using ToyStore.Models;

    public class CategoriesSeeder : ToyStoreSeeder, IToyStoreSeeder
    {
        public CategoriesSeeder(ToyStoreEntities db, IRandomDataGenerator ran, int count)
            : base(db, ran, count)
        {
        }

        public override void Seed()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.Database.Categories.Add(new Category() { Name = this.Random.GetString(1, 30) });
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

namespace ToyStore.Seeder
{
    using System.Collections.Generic;
    using ToyStore.Models;

    public class ManufacturerSeeder : ToyStoreSeeder, IToyStoreSeeder
    {
        public ManufacturerSeeder(ToyStoreEntities db, IRandomDataGenerator ran, int count)
            : base(db, ran, count)
        {
        }

        public override void Seed()
        {
            var companies = new HashSet<string>();
            while (companies.Count < this.Count)
            {
                companies.Add(this.Random.GetString(1, 50));
            }

            int i = 0;
            foreach (var name in companies)
            {
                this.Database.Manufacturers.Add(new Manufacturer() { Name = name, Country = this.Random.GetString(1, 50) });
                i++;
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

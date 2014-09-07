namespace ToyStore.Seeder
{
    using System.Collections.Generic;
    using ToyStore.Models;

    public class AgeRangesSeeder : ToyStoreSeeder, IToyStoreSeeder
    {
        public AgeRangesSeeder(ToyStoreEntities db, IRandomDataGenerator ran, int count)
            : base(db, ran, count)
        {
        }

        public override void Seed()
        {
            for (int i = 0; i < this.Count; i++)
            {
                int min, max;
                do
                {
                    min = this.Random.GetInt(1, 100);
                    max = this.Random.GetInt(min, 100);
                }
                while (min > max);

                this.Database.AgeRanges.Add(new AgeRanx() { MaxAge = max, MinAge = min });
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

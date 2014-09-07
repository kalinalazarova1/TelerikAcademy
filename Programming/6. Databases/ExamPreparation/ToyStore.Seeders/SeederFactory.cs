namespace ToyStore.Seeder
{
    using ToyStore.Models;

    public class SeederFactory : ISeederFactory
    {
        private ToyStoreEntities db;
        private IRandomDataGenerator ran;

        public SeederFactory(ToyStoreEntities db, IRandomDataGenerator ran)
        {
            this.db = db;
            this.ran = ran;
        }

        public IToyStoreSeeder GetToysSeeder(int count)
        {
            return new ToysSeeder(this.db, this.ran, count);
        }

        public IToyStoreSeeder GetAgeRangesSeeder(int count)
        {
            return new AgeRangesSeeder(this.db, this.ran, count);
        }

        public IToyStoreSeeder GetCategoriesSeeder(int count)
        {
            return new CategoriesSeeder(this.db, this.ran, count);
        }

        public IToyStoreSeeder GetManufacturerSeeder(int count)
        {
            return new ManufacturerSeeder(this.db, this.ran, count);
        }
    }
}

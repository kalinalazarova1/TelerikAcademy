namespace ToyStore.Seeder
{
    using ToyStore.Models;

    internal class ToyStoreSeederEntryPoint
    {
        internal static void Main()
        {
            var db = new ToyStoreEntities();
            var ran = RandomDataGenerator.Instance;
            var factory = new SeederFactory(db, ran);

            db.Configuration.AutoDetectChangesEnabled = false;

            factory.GetManufacturerSeeder(50).Seed();
            factory.GetCategoriesSeeder(100).Seed();
            factory.GetAgeRangesSeeder(100).Seed();
            factory.GetToysSeeder(20000).Seed();

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}

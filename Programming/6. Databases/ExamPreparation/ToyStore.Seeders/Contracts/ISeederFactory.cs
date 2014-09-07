namespace ToyStore.Seeder
{
    using ToyStore.Models;

    public interface ISeederFactory
    {
        IToyStoreSeeder GetToysSeeder(int count);

        IToyStoreSeeder GetAgeRangesSeeder(int count);

        IToyStoreSeeder GetCategoriesSeeder(int count);

        IToyStoreSeeder GetManufacturerSeeder(int count);
    }
}

namespace ToyStore.Seeder
{
    public interface IRandomDataGenerator
    {
        string GetString(int min, int max);

        int GetInt(int min, int max);

        double GetDouble();

        bool GetChance(int percent);
    }
}

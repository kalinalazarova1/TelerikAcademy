namespace ToyStore.Seeder
{
    using ToyStore.Models;

    public abstract class ToyStoreSeeder : IToyStoreSeeder
    {
        // TODO: ILogger to log messages when data seeded and a ConsoleLogger to log them in the console.
        private ToyStoreEntities db;
        private IRandomDataGenerator ran;
        private int count;

        public ToyStoreSeeder(ToyStoreEntities db, IRandomDataGenerator ran, int count)
        {
            this.ran = ran;
            this.db = db;
            this.count = count;
        }

        protected ToyStoreEntities Database 
        {
            get
            {
                return this.db;
            }
        }

        protected IRandomDataGenerator Random 
        {
            get
            {
                return this.ran;
            }
        }

        protected int Count 
        {
            get
            {
                return this.count;
            }

            set
            {
                this.count = value;
            }
        }

        public abstract void Seed();
    }
}

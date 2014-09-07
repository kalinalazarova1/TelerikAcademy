namespace Atm.Data
{
    using System.Data.Entity;
    using Atm.Data.Migrations;
    using Atm.Models;

    public class AtmDataDbContext : DbContext
    {
        public AtmDataDbContext()
            : base("ATM")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDataDbContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionsHistory> TransactionsHistories { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}

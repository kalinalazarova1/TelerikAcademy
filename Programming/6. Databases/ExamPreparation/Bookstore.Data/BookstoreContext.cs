namespace Bookstore.Data
{
    using System.Data.Entity;
    using Bookstore.Data.Migrations;
    using Bookstore.Models;

    public class BookstoreContext : DbContext
    {
        public BookstoreContext()
            : base("Bookstore")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Author> Authors { get; set; }

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

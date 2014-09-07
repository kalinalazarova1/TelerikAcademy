// 7. Try to open two different data contexts and perform concurrent changes on the same records. 
// What will happen at SaveChanges()? How to deal with it?

// On SaveChanges on random is saved "Pesho" or "Gosho". Try few times and watch the result in the SQL Management Studio.

namespace _07.ConcurrentChanges
{
    using System.Linq;
    using Northwind.Data;

    internal class ConcurrentChanges
    {
        internal static void Main()
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var dbCopy = new NorthwindEntities();
                using (dbCopy)
                {
                    var first = db.Categories.Where(c => c.CategoryID == 1).First();
                    first.CategoryName = "Pesho";
                    var second = dbCopy.Categories.Where(c => c.CategoryID == 1).First();
                    second.CategoryName = "Gosho";
                    db.SaveChanges();
                    dbCopy.SaveChanges();
                }
            }
        }
    }
}

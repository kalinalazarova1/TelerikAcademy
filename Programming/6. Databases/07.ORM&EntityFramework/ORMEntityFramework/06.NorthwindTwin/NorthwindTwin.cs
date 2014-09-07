// 6. Create a database called NorthwindTwin with the same structure as Northwind using the features
// from DbContext. Find for the API for schema generation in MSDN or in Google.

namespace _06.NorthwindTwin
{
    using Northwind.Data;

    internal class NorthwindTwin
    {
        internal static void Main()
        {
            var db = new NorthwindEntities();
            using (db)
            {
                db.Database.CreateIfNotExists();
            }
        }
    }
}

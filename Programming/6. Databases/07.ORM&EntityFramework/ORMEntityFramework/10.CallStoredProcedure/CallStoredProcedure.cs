// 10. Create a stored procedures in the Northwind database for finding the total incomes for given supplier name and period
// (start date, end date). Implement a C# method that calls the stored procedure and returns the retuned record set.

namespace _10.CallStoredProcedure
{
    using System;
    using System.Linq;
    using Northwind.Data;

    internal class CallStoredProcedure
    {
        internal static void Main(string[] args)
        {
            var start = new DateTime(1997, 08, 24);
            var end = new DateTime(1997, 08, 30);
            var supplierId = 1;
            var result = GetIncomeByPeriodAndSupplier(start, end, supplierId);
            Console.WriteLine("Total income {0} for supplier with id {1} from {2:dd.MM.yyyy} to {3:dd.MM.yyyy}", result, supplierId, start, end);
        }
        
        private static decimal? GetIncomeByPeriodAndSupplier(DateTime start, DateTime end, int supplierId)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var result = db.IncomeFromSupplierAndPeriod(start, end, 1).Select(r => r.Value).First();
                return result;    
            }
        }
    }
}

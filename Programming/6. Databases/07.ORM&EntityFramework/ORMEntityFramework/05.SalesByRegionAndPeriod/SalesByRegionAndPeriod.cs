// 5.Write a method that finds all the sales by specified region and period (start / end dates).

namespace _05.SalesByRegionAndPeriod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Northwind.Data;

    internal class SalesByRegionAndPeriod
    {
        internal static void Main()
        {
            var start = new DateTime(1997, 4, 1);
            var end = new DateTime(1997, 6, 30);
            var region = "RJ";
            var sales = SalesByPeriodAndRegion(start, end, region);
            Console.WriteLine("Total sales: {0:0.00} from {1:dd.MM.yyyy} to {2:dd.MM.yyyy} in region {3}.", sales.Sum(s => s.Value), start, end, region);
        }

        private static IEnumerable<KeyValuePair<DateTime?, decimal?>> SalesByPeriodAndRegion(DateTime startDate, DateTime endDate, string region)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var sales = db.Orders
                    .Where(o => o.ShippedDate <= endDate && o.ShippedDate >= startDate && o.ShipRegion == region)
                    .Join(db.Order_Subtotals, o => o.OrderID, d => d.OrderID, (o, d) => new { o = o, d = d })
                    .Select(r => new
                    {
                        Date = r.o.ShippedDate,
                        Sales = r.d.Subtotal
                    })
                    .ToList();

                var result = new Dictionary<DateTime?, decimal?>();
                foreach (var sale in sales)
                {
                    result.Add(sale.Date, sale.Sales);
                }

                return result;
            }
        }
    }
}

// 2.Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), 
// then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() and finally checks whether 
// the town is "Sofia". Rewrite the same in more optimized way and compare the performance.

namespace _02.ToListPerformance
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using TelerikAcademy.Models;

    internal class ToListPerformance
    {
        internal static void Main()
        {
            var stopwatch = new Stopwatch();
            var context = new TelerikAcademyEntities();
            stopwatch.Start();
            var employees = context.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).Where(t => t.Name == "Sofia");
            Console.WriteLine("Count: {0}", employees.Count());
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} seconds", (decimal)stopwatch.Elapsed.Milliseconds / 1000);

            stopwatch.Reset();
            stopwatch.Start();
            var optimizedEmployees = context.Employees.Select(e => e.Address).Select(a => a.Town).Where(t => t.Name == "Sofia");
            Console.WriteLine("Count: {0}", optimizedEmployees.Count());
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} seconds", (decimal)stopwatch.Elapsed.Milliseconds / 1000);
        }
    }
}

// 1.Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, 
// department and town. Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.

namespace _01.IncludePerformance
{
    using System;
    using System.Diagnostics;
    using TelerikAcademy.Models;

    internal class IncludePerfomance
    {
        internal static void Main()
        {
            var stopwatch = new Stopwatch();
            var context = new TelerikAcademyEntities();
            stopwatch.Start();
            var employees = context.Employees;
            foreach (var employee in employees)
            {
                Console.WriteLine(
                    "{0}, {1}, {2}",
                    (employee.FirstName + ' ' + employee.LastName).PadLeft(30),
                    employee.Department.Name.PadLeft(30),
                    employee.Address.Town.Name.PadLeft(15));
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} seconds", (decimal)stopwatch.Elapsed.Milliseconds / 1000);

            stopwatch.Reset();
            stopwatch.Start();
            var includeEmployees = context.Employees.Include("Address").Include("Department");
            foreach (var employee in includeEmployees)
            {
                Console.WriteLine(
                    "{0}, {1}, {2}",
                    (employee.FirstName + ' ' + employee.LastName).PadLeft(30),
                    employee.Department.Name.PadLeft(30),
                    employee.Address.Town.Name.PadLeft(15));
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} seconds", (decimal)stopwatch.Elapsed.Milliseconds / 1000);
        }
    }
}

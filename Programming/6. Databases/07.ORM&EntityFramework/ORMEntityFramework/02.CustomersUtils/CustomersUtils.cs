// 2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. 
// Write a testing class.
// 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

namespace _02.CustomersUtils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Northwind.Data;

    public static class CustomersUtils
    {
        public static IEnumerable<string> GetOrdersShippedToAndMadeFromYear(string country, int year)
        {   
            var db = new NorthwindEntities();
            using (db)
            {
                return db.Orders
                    .Where(o => o.ShipCountry == country && o.OrderDate.Value.Year == year)
                    .GroupBy(o => o.Customer.CompanyName)
                    .Select(g => g.Key)
                    .ToList();
            }
        }

        public static IEnumerable<string> GetWithSQLOrdersShippedToAndMadeFromYear(string country, int year)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                string nativeSqlQuery = 
                    "SELECT CompanyName FROM Customers c " +
                    "INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                    "WHERE c.Country = '" +
                    country +
                    "' AND YEAR(o.OrderDate) = " +
                    year +
                    "GROUP BY CompanyName";
                object[] parameters = { country, year };
                var companies = db.Database.SqlQuery<string>(nativeSqlQuery, parameters);
                return companies.ToList();
            }
        }

        public static void InsertNewCustomer(
            string id,
            string company,
            string name = null,
            string title = null,
            string address = null,
            string city = null,
            string region = null,
            string code = null,
            string country = null,
            string phone = null,
            string fax = null)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var newcustomer = new Customer
                {
                    CustomerID = id,
                    CompanyName = company,
                    ContactName = name,
                    ContactTitle = title,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = code,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };
                db.Customers.Add(newcustomer);
                db.SaveChanges();
            }
        }

        public static void ModifyCustomer(
        string id,
        string company,
        string name,
        string title,
        string address,
        string city,
        string region,
        string code,
        string country,
        string phone,
        string fax)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var newCustomer = new Customer
                {
                    CustomerID = id,
                    CompanyName = company,
                    ContactName = name,
                    ContactTitle = title,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = code,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };
                var forRemoval = db.Customers.Find(id);
                if (forRemoval != null)
                {
                    db.Customers.Remove(forRemoval);
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                }
            }
        }

        public static void RemoveCustomer(string id)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var forRemoval = db.Customers.Find(id);
                if (id != null)
                {
                    db.Customers.Remove(forRemoval);
                    db.SaveChanges();
                }
            }
        }
    }
}

namespace _09.CreateNewOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Transactions;
    using Northwind.Data;

    internal class CreateNewOrderTest
    {
        internal static void Main()
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var transaction = db.Database.BeginTransaction();
                    try
                    {
                        var header = new Order() { CustomerID = "ALFKI", OrderDate = new DateTime(2014, 08, 21) };
                        var added = db.Orders.Add(header);
                        
                        var rows = new Order_Detail[3];
                        rows[0] = new Order_Detail() { OrderID = added.OrderID, ProductID = 1, Quantity = 100, UnitPrice = 0.80m };
                        rows[1] = new Order_Detail() { OrderID = added.OrderID, ProductID = 2, Quantity = 100, UnitPrice = 1.50m };
                        rows[2] = new Order_Detail() { OrderID = added.OrderID, ProductID = 3, Quantity = 100, UnitPrice = 2.50m };
                        header.Order_Details.Add(rows[0]);
                        header.Order_Details.Add(rows[1]);
                        header.Order_Details.Add(rows[2]);
                        db.SaveChanges();

                        header = new Order() { CustomerID = "ALFKI", OrderDate = new DateTime(2014, 08, 30) };
                        added = db.Orders.Add(header);
                        rows = new Order_Detail[3];
                        //// header.Order_Details.Add(new Order_Detail()); // this row will give exception and the transaction will be rolled back 
                        db.SaveChanges();
                        Console.WriteLine("Transaction completed successfully.");
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Transaction not completed. Changes rolled back.");
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
            }
        }
    }
}

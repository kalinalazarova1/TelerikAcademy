// 4.Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.

namespace _04.AddProduct
{
    using System;
    using System.Data.SqlClient;

    internal class AddProduct
    {
        internal static void Main()
        {
            AddSingleProduct("Test Product", 3, 6, "10 boxes", 2.50m, 100, null, null, false);
            Console.WriteLine("Check the database to see the added product");
        }

        private static void AddSingleProduct(
            string name,
            int supplierId,
            int categoryId,
            string quantityPerUnit,
            decimal? unitPrice,
            int? unitsInStock,
            int? unitsOnOrder,
            int? reorderLevel,
            bool discontinued)
        {
            var dbCon = new SqlConnection(Settings.Default.DBConnectionString);
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Products " +
                    "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES " +
                    "(@name, @sId, @cId, @qpu, @price, @inStock, @ordered, @level, @discont)",
                    dbCon);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@sId", supplierId);
                cmd.Parameters.AddWithValue("@cId", categoryId);
                var sqlParameterQuanPerUnit = new SqlParameter("@qpu", quantityPerUnit);
                if (quantityPerUnit == null)
                {
                    sqlParameterQuanPerUnit.Value = DBNull.Value;
                }

                cmd.Parameters.Add(sqlParameterQuanPerUnit);
                var sqlParameterUnitPrice = new SqlParameter("@price", unitPrice);
                if (unitPrice == null)
                {
                    sqlParameterUnitPrice.Value = DBNull.Value;
                }

                cmd.Parameters.Add(sqlParameterUnitPrice);
                var sqlParameterInStock = new SqlParameter("@inStock", unitsInStock);
                if (unitsInStock == null)
                {
                    sqlParameterInStock.Value = DBNull.Value;
                }

                cmd.Parameters.Add(sqlParameterInStock);
                var sqlParameterOrdered = new SqlParameter("@ordered", unitsOnOrder);
                if (unitsOnOrder == null)
                {
                    sqlParameterOrdered.Value = DBNull.Value;
                }

                cmd.Parameters.Add(sqlParameterOrdered);
                var sqlParameterLevel = new SqlParameter("@level", reorderLevel);
                if (reorderLevel == null)
                {
                    sqlParameterLevel.Value = DBNull.Value;
                }

                cmd.Parameters.Add(sqlParameterLevel);
                cmd.Parameters.AddWithValue("@discont", discontinued);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

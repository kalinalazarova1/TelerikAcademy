// 3. Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
// Can you do this with a single SQL query (with table join)?

namespace _03.ProductCategories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    internal class ProductCategories
    {
        internal static void Main()
        {
            {
                var dbCon = new SqlConnection(Settings.Default.DBConnectionString);
                dbCon.Open();
                using (dbCon)
                {
                    var command = new SqlCommand(
                        "SELECT p.ProductName, c.CategoryName FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID ORDER BY c.CategoryName", dbCon);
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        var previous = string.Empty;
                        var allProducts = new List<string>();
                        while (reader.Read())
                        {
                            string category = (string)reader["CategoryName"];
                            string product = (string)reader["ProductName"];
                            if(previous == category || previous == string.Empty)
                            {
                                allProducts.Add(product);
                            }
                            else
                            {
                                Console.WriteLine("Category: {0} -> Products: {1}", previous, string.Join(",", allProducts));
                                Console.WriteLine();
                                allProducts.Clear();
                                allProducts.Add(product);
                            }

                            previous = category;
                        }
                    }

                }
            }
        }
    }
}

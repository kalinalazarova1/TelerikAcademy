// 2. Write a program that retrieves the name and description of all categories in the Northwind DB.

namespace _02.NameDescriptionCategories
{
    using System;
    using System.Data.SqlClient;

    internal class NameDescription
    {
        internal static void Main()
        {
            {
                var dbCon = new SqlConnection(Settings.Default.DBConnectionString);
                dbCon.Open();
                using (dbCon)
                {
                    var command = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader["CategoryName"];
                            string description = (string)reader["Description"];
                            Console.WriteLine("Category: {0}, Description: {1};", name, description);
                        }
                    }
                }
            }
        }
    }
}

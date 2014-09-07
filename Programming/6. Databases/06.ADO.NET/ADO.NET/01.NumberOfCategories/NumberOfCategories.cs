// 1.Write a program that retrieves from the Northwind sample database in MS SQL Server the number of rows in the Categories table.

namespace _01.NumberOfCategories
{
    using System;
    using System.Data.SqlClient;

    internal class NumberOfCategories
    {
        internal static void Main()
        {
            SqlConnection dbCon = new SqlConnection(DBConnection.Default.DBConnectionString);
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesCount = (int)command.ExecuteScalar();
                Console.WriteLine("Categories rows count: {0} ", categoriesCount);
            }
        }
    }
}

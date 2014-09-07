// 8. Write a program that reads a string from the console and finds all products that contain this string. 
// Ensure you handle correctly characters like ', %, ", \ and _.

namespace _08.SearchProduct
{
    using System;
    using System.Data.SqlClient;

    internal class SearchProduct
    {
        internal static void Main()
        {
            Console.WriteLine("Please input product search string:");
            var searchString = Console.ReadLine();
            var dbCon = new SqlConnection(Settings.Default.DBConnectionString);
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT ProductName FROM Products WHERE CHARINDEX(@searchString, ProductName) > 0",
                    dbCon);
                cmd.Parameters.AddWithValue("@searchString", searchString);
                var reader = cmd.ExecuteReader();
                Console.WriteLine("Found products:");
                using(reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["ProductName"];
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}

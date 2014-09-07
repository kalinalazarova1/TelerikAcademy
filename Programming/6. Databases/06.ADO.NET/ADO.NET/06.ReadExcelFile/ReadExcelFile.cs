// 6.Create an Excel file with 2 columns: name and score:
// Write a program that reads your MS Excel file through the OLE DB data provider
// and displays the name and score row by row.

namespace _06.ReadExcelFile
{
    using System;
    using System.Data.OleDb;

    internal class ReadExcelFile
    {
        internal static void Main()
        {
            OleDbConnection dbConn = new OleDbConnection(Settings.Default.OleDBConnectionString);
            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Table$]", dbConn);
                cmd.Connection = dbConn;
                var reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = (string)reader["Name"];
                        var score = (double)reader["Score"];
                        Console.WriteLine("Name: {0} -> Score: {1};", name, score);
                    }
                }
            }
        }
    }
}

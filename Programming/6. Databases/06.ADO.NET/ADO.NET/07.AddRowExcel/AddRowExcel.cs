// 7. Implement appending new rows to the Excel file.

namespace _07.AddRowExcel
{
    using System;
    using System.Data.OleDb;

    internal class AddRowExcel
    {
        internal static void Main()
        {
            var name = "Ivaylo Kenov";
            var score = 21.0;
            OleDbConnection dbConn = new OleDbConnection(Settings.Default.OleDBConnectionString);
            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [Table$] (Name, Score) VALUES(@name, @score)", dbConn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.Connection = dbConn;
                cmd.ExecuteNonQuery();
            }
        }
    }
}

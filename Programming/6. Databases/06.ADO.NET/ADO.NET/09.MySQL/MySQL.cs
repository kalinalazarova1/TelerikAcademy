// 9. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool . 
// Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, finding a book by 
// name and adding a book.

namespace _09.MySQL
{
    using System;
    using MySql.Data.MySqlClient;

    internal class MySQL
    {
        internal static void Main()
        {
            Console.WriteLine("List before adding:");
            ListAllBooks();
            AddBook("Fake book", "Fake Author", new DateTime(2014, 08, 27), "1234567890123");
            Console.WriteLine("List after adding:");
            ListAllBooks();
            Console.WriteLine("Please input book title:");
            var title = Console.ReadLine();
            FindBookByTitle(title);
        }

        private static void ListAllBooks()
        {
            var con = new MySqlConnection(Settings.Default.DBConnectionString);
            con.Open();
            using (con)
            {
                var cmd = new MySqlCommand("SELECT Title, Author FROM books", con);
                var reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var title = (string)reader["Title"];
                        var author = (string)reader["Author"];
                        Console.WriteLine("Author: {0}\tTitle: {1}", author, title);
                    }
                }
            }
        }

        private static void AddBook(string title, string author, DateTime publishDate, string isbn)
        {
            var con = new MySqlConnection(Settings.Default.DBConnectionString);
            con.Open();
            using (con)
            {
                var cmd = new MySqlCommand(
                        "INSERT INTO books " +
                        "(Title, Author, PublishDate, ISBN) VALUES " +
                        "(@title, @author, @publishDate, @isbn)",
                        con);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@publishDate", publishDate);
                cmd.Parameters.AddWithValue("@isbn", isbn);
                cmd.ExecuteNonQuery();
            }
        }

        private static void FindBookByTitle(string title)
        {
            var con = new MySqlConnection(Settings.Default.DBConnectionString);
            con.Open();
            using (con)
            {
                var cmd = new MySqlCommand(
                    "SELECT Title FROM books WHERE Title = @title",
                    con);
                cmd.Parameters.AddWithValue("@title", title);
                var reader = cmd.ExecuteReader();
                Console.WriteLine("Found Titles:");
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Title"];
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}

// 5.Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.

namespace _05.SaveImagesToJPG
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;

    internal class SaveImagesToJPG
    {
        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

        static void Main()
        {
            SqlConnection dbConn = new SqlConnection(Settings.Default.DBConnectionString);
            dbConn.Open();
            using (dbConn)
            {
                SqlCommand cmd = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbConn);
                var reader = cmd.ExecuteReader();
                var result = new List<byte[]>();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var imageWithHeader = (byte[])reader["Picture"];    // pictures from the Northwind database have 78 bytes header which have to be skipped
                        var image = new byte[imageWithHeader.Length - 78];
                        Array.Copy(imageWithHeader, 78, image, 0, image.Length);
                        var categoryName = (string)reader["CategoryName"];
                        var filename = categoryName.Replace('/','_') + ".jpg";
                        WriteBinaryFile(filename, image);
                        Console.WriteLine("Image saved to file {0}.", filename);    // you could see the saved images in the bin/debug folder of the project
                    }
                }
            }
        }
    }
}

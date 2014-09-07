namespace _09.DirectoriesToXml
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class DirectoriesToXml
    {
        public static void Main()
        {
            DirectoryInfo rootDir = new DirectoryInfo(@"../../");
            Encoding encoding = Encoding.GetEncoding("utf-8");
            using (XmlTextWriter writer = new XmlTextWriter("../../AlbumCatalog.xml", encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("root");

                WalkDirectoryTree(writer, rootDir);
            }
        }

        public static void WalkDirectoryTree(XmlTextWriter writer, DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (DirectoryNotFoundException)
            {
            }

            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    writer.WriteElementString("file", file.Name);
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    writer.WriteStartElement("dir", dirInfo.Name);
                    WalkDirectoryTree(writer, dirInfo);
                    writer.WriteEndElement();
                }
            }
        }
    }
}

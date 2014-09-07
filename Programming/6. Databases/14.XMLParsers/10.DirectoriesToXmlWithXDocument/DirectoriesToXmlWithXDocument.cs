namespace _10.DirectoriesToXmlWithXDocument
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;

    public class DirectoriesToXmlWithXDocument
    {
        public static void Main()
        {
            DirectoryInfo rootDir = new DirectoryInfo(@"../../");
            var xmlCatalog = new XElement("root");
            WalkDirectoryTree(xmlCatalog, rootDir);
            xmlCatalog.Save("../../AlbumCatalog.xml");
        }

        public static void WalkDirectoryTree(XElement parent, DirectoryInfo root)
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
                    parent.Add(new XElement("file", file.Name));
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    var directory = new XElement("dir", dirInfo.Name);
                    parent.Add(directory);
                    WalkDirectoryTree(directory, dirInfo);
                }
            }
        }
    }
}

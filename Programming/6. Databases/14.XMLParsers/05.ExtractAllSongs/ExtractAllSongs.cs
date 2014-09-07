namespace _05.ExtractAllSongs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    internal class ExtractAllSongs
    {
        internal static void Main()
        {
            Console.WriteLine("Song titles in the catalogue albums:");
            using (XmlReader reader = XmlReader.Create("../../../MusicCatalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}

namespace _08.CreateXMLWithXMLWriter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    internal class CreateXmlWithXmlWriter
    {
        internal static void Main()
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            using (XmlTextWriter writer = new XmlTextWriter("../../AlbumCatalog.xml", encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("catalogue");
                
                using (XmlReader reader = XmlReader.Create("../../../MusicCatalog.xml"))
                {
                    do
                    {
                        var current = reader.Read();
                        while (current && !(reader.NodeType == XmlNodeType.Element && reader.Name == "name"))
                        {
                            current = reader.Read();
                        }

                        string title = string.Empty;
                        if (current && reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                        {
                            title = reader.ReadElementString(); 
                        }

                        while (current && !(reader.NodeType == XmlNodeType.Element && reader.Name == "artist"))
                        {
                            current = reader.Read();
                        }

                        string artist = string.Empty;
                        if (current && reader.NodeType == XmlNodeType.Element && reader.Name == "artist")
                        {
                            artist = reader.ReadElementString();
                            writer.WriteStartElement("album");
                            writer.WriteElementString("title", title);
                            writer.WriteElementString("artist", artist);
                            writer.WriteEndElement();
                            current = reader.Read();
                        }
                    }
                    while (reader.Read());
                }

                writer.WriteEndDocument();
            }
        }
    }
}

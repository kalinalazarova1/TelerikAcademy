namespace _01.ExtractAuthorsAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    internal class AblumsCount
    {
        internal static void Main()
        {
            var result = new Dictionary<string, int>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../MusicCatalog.xml");
            XmlNode rootNode = xmlDoc.DocumentElement;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                string artistName = node["artist"].InnerText;
                if (result.ContainsKey(artistName))
                {
                    result[artistName]++;
                }
                else
                {
                    result[artistName] = 1;
                }
            }

            foreach (var artist in result)
            {
                Console.WriteLine("Arist: {0}, Albums count: {1}", artist.Key, artist.Value);
            }
        }
    }
}

namespace _02.AlbumCountXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    internal class AlbumCountWithXPath
    {
        internal static void Main()
        {
            var result = new Dictionary<string, int>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../MusicCatalog.xml");
            string xPathQuery = "/catalogue/album/artist";

            XmlNodeList artistList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode artist in artistList)
            {
                string artistName = artist.InnerText;
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

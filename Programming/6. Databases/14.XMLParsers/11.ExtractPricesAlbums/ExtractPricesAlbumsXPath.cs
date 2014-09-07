namespace _11.ExtractPricesAlbums
{
    using System;
    using System.Xml;

    internal class ExtractPricesAlbumsXPath
    {
        internal static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../MusicCatalog.xml");
            string xPathQuery = "/catalogue/album[year<2009]";

            XmlNodeList albumList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode album in albumList)
            {
                var title = album.SelectSingleNode("name").InnerText;
                var year = album.SelectSingleNode("year").InnerText;
                var price = album.SelectSingleNode("price").InnerText;
                Console.WriteLine("Album: {0}, Year: {1}, Price: {2}", title, year, price);
            }
        }
    }
}

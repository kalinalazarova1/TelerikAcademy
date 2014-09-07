namespace _12.ExtractPricesAlbumsLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    internal class ExtractPricesAlbumsLinq
    {
        internal static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../../MusicCatalog.xml");
            var albums = xmlDoc.Descendants("album")
                .Where(a => int.Parse(a.Element("year").Value) < 2009);

            foreach (var album in albums)
            {
                var title = album.Element("name").Value;
                var year = album.Element("year").Value;
                var price = album.Element("price").Value;
                Console.WriteLine("Album: {0}, Year: {1}, Price: {2}", title, year, price);
            }
        }
    }
}

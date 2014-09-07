namespace _06.ExtractSongsWithLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    internal class ExtractSongsWithLinq
    {
        internal static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../../MusicCatalog.xml");
            var titles = xmlDoc.Descendants("title").Select(s => s.Value);

            Console.WriteLine("Song titles in the catalogue albums:");
            foreach (var song in titles)
            {
                Console.WriteLine(song);
            }
        }
    }
}

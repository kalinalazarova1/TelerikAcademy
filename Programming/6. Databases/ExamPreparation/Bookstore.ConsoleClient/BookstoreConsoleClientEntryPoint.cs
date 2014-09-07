namespace Bookstore.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Bookstore.Data;
    using Bookstore.Models;
    using Bookstore.Parsers;

    internal class BookstoreConsoleClientEntryPoint
    {
        internal static void Main()
        {
            var db = new BookstoreContext();
            var xmlDoc = XElement.Load(@"../../../DataFiles/complex-books.xml");
            var parser = new DataParser(db, xmlDoc);
            parser.Parse();
            xmlDoc = XElement.Load(@"../../../DataFiles/reviews-queries.xml");
            var querer = new QueryParser(db, xmlDoc);
            querer.Parse();
        }   
    }
}

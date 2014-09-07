namespace TelerikAcademyForumRss
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class TelerikAcademyForumRss
    {
        internal static void Main()
        {
            // 1.The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
            // 2.Download the content of the feed programmatically
            // You can use WebClient.DownloadFile()
            using (var client = new WebClient())
            {
                client.DownloadFile(@"http://forums.academy.telerik.com/feed/qa.rss", @"../../forum.xml");
            }

            // 3.Parse the XML from the feed to JSON
            var forumXml = XElement.Load("../../forum.xml");
            string jsonForumRss = JsonConvert.SerializeXNode(forumXml, Formatting.Indented);
            Console.WriteLine(jsonForumRss);

            // 4.Using LINQ-to-JSON select all the question titles and print them to the console
            var titles = JObject.Parse(jsonForumRss)["rss"]["channel"]["item"].Select(i => i["title"]);
            Console.WriteLine(string.Join(Environment.NewLine, titles));

            // 5.Parse the JSON string to POCO
            var items = JsonConvert.DeserializeObject<Item[]>(JObject.Parse(jsonForumRss)["rss"]["channel"]["item"].ToString());
            Console.WriteLine(string.Join(Environment.NewLine, items.ToList()));

            // 6.Using the parsed objects create a HTML page that lists all questions from the RSS their categories 
            // and a link to the question's page
            GenerateHtml(items);
        }

        private static void GenerateHtml(Item[] items)
        {
            var feedHtml = new StringBuilder();
            feedHtml.Append("<html><head><meta charset=\"utf-8\" /><title>Telerik Academy Forum</title></head><body><ul>");
            foreach (var item in items)
            {
                feedHtml.AppendFormat("<li>{2} : <a href=\"{0}\">{1}</a></li>", item.Link, item.Title, item.Category);
            }

            feedHtml.Append("</ul></body></html>");
            using (var writer = new StreamWriter("../../forum.html"))
            {
                writer.Write(feedHtml);
            }
        }
    }
}

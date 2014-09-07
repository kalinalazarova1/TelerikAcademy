namespace _04.DeleteXMLElementWithDOMParser
{
    using System.Xml;

    internal class DeleteWithDom
    {
        internal static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../MusicCatalog.xml");

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (double.Parse(node["price"].InnerText) > 20)
                {
                    xmlDoc.DocumentElement.RemoveChild(node);
                }
            }

            xmlDoc.Save("../../../MusicCatalog.xml");
        }
    }
}

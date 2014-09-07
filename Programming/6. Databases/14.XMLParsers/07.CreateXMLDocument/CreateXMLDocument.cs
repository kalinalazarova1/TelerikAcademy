namespace _07.CreateXMLDocument
{
    using System.IO;
    using System.Xml.Linq;

    internal class CreateXMLDocument
    {
        internal static void Main()
        {
            XNamespace ns = "urn:phonebook";
            using (var reader = new StreamReader("../../../phonebook.txt"))
            {
                XElement phonebookXml = new XElement(ns + "phonebook");
                var name = reader.ReadLine();
                var adderess = reader.ReadLine();
                var phone = reader.ReadLine();

                while (name != null)
                {
                    XElement personXml = new XElement(
                        ns + "person",
                        new XElement(ns + "name", name),
                        new XElement(ns + "address", adderess),
                        new XElement(ns + "phone", phone));
                    phonebookXml.Add(personXml);
                    name = reader.ReadLine();
                    adderess = reader.ReadLine();
                    phone = reader.ReadLine();
                }

                phonebookXml.Save("../../phonebook.xml");
            }
        }
    }
}

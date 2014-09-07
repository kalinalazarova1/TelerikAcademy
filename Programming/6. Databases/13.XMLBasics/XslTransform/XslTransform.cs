namespace XslTransform
{
    using System.Xml.Xsl;

    internal class XslTransform
    {
        internal static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../Students.xslt");
            xslt.Transform("../../../Students.xml", "../../../Students.html");
        }
    }
}

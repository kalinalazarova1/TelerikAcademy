namespace _14.XSLTransform
{
    using System;
    using System.Xml.Xsl;

    internal class XSLTransformUsage
    {
        internal static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../MusicCatalog.xslt");
            xslt.Transform("../../../MusicCatalog.xml", "../../../MusicCatalog.html");
        }
    }
}

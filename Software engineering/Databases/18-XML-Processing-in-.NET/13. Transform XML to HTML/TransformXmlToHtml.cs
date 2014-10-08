namespace ProcessingXml
{
    using System.Xml.Xsl;

    /// <summary>
    /// 13. Task
    /// Create an XSL stylesheet, which transforms the file catalog.xmlinto HTML document, 
    /// formatted for viewing in a standard Web-browser.
    /// </summary>
    public class TransformXmlToHtml
    {
        internal static void Main()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../catalog.xsl");
            xslt.Transform("../../catalog.xml", "../../catalog.html");
        }
    }
}
namespace ProcessingXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// 12. Task
    /// Rewrite the previous using LINQ query.
    /// </summary>
    public class ExtractPriceOfAlbumsUsingLinq
    {
        private const int YearDifference = 5;

        internal static void Main()
        {
            var catalogXml = XDocument.Load("../../catalog.xml");
            var albumsXml = catalogXml.Element("catalog")
                                      .Element("albums")
                                      .Elements("album");

            var songTitles = from album in albumsXml
                             where DateTime.Now.AddYears(-int.Parse(album.Element("year").Value)).Year <= YearDifference
                             select album.Element("price").Value;

            Console.WriteLine("Extracted price(s): {0}", string.Join(", ", songTitles));
        }
    }
}
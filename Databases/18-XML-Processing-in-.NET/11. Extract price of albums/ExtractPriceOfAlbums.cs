namespace ProcessingXml
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// 11. Task
    /// Write a program, which extract from the file catalog.xmlthe prices for all albums, p
    /// ublished 5 years ago or earlier. Use XPath query.
    /// </summary>
    public class ExtractPriceOfAlbums
    {
        private const int YearDifference = 5;

        internal static void Main()
        {
            var catalogXml = new XmlDocument();
            catalogXml.Load("../../catalog.xml");

            var prices = ExtractAllPricesOfAlbums(catalogXml);
            Console.WriteLine("Extracted price(s): {0}", string.Join(", ", prices));
        }

        private static ICollection<string> ExtractAllPricesOfAlbums(XmlDocument xmlDocument)
        {
            var prices = new List<string>();
            var albumsXml = xmlDocument.SelectNodes("/catalog/albums/album");

            foreach (XmlNode album in albumsXml)
            {
                var albumYear = int.Parse(album.SelectSingleNode("year").InnerText);

                if (DateTime.Now.AddYears(-albumYear).Year <= YearDifference)
                {
                    var price = album.SelectSingleNode("price").InnerText;
                    prices.Add(price);
                }
            }

            return prices;
        }
    }
}
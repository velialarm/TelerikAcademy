namespace _04.Delete_Element
{
    using System.Xml;

    /// <summary>
    /// 4. Task
    /// Using the DOM parser write a program to delete from catalog.xmlall albums having price > 20.
    /// </summary>
    public class Program
    {
        private const int MaxPrice = 15;

        public static void Main(string[] args)
        {
            var catalogXml = new XmlDocument();
            catalogXml.Load("../../catalog.xml");

            var albumsParent = catalogXml.SelectSingleNode("catalog/albums");
            var albumsXml = albumsParent.SelectNodes("album");

            foreach (XmlNode album in albumsXml)
            {
                var priceXml = album.SelectSingleNode("price").InnerText.Replace("$", string.Empty);
                var priceAsDouble = double.Parse(priceXml);

                if (priceAsDouble > MaxPrice)
                {
                    albumsParent.RemoveChild(album);
                }
            }

            catalogXml.Save("../../new-catalog.xml");
        }
    }
}

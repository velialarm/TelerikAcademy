namespace _06.ExtractAllSong_with_Linq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// 6. Task
    /// Rewrite the same using XDocumentand LINQ query.
    /// </summary>
    public class ExtractAllSong
    {
        public static void Main()
        {
            var catalogXml = XDocument.Load("../../catalog.xml");
            var albumsXml = catalogXml.Element("catalog")
                                      .Element("albums")
                                      .Elements("album");

            var songTitles = from songName in albumsXml.Descendants("title")
                             select new
                             {
                                 Title = songName.Value
                             };

            Console.WriteLine("All song titles:\n");
            foreach (var song in songTitles)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}

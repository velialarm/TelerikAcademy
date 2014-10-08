﻿namespace _03.Parse_XML_with_XPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// 3. Task
    /// Implement the previous using XPath.
    /// </summary>
    public class ParseXml
    {
        public static void Main(string[] args)
        {
            var catalogXml = new XmlDocument();
            catalogXml.Load("../../catalog.xml");

            var artistNames = ExtractAllArtistNames(catalogXml);
            Console.WriteLine("All artists: {0}\n", string.Join(", ", artistNames));

            var bandsAlbums = ExtractNumberOfAlbumsForEachBand(catalogXml);
            foreach (var bandAlbum in bandsAlbums)
            {
                Console.WriteLine("{0}: {1} song(s)", bandAlbum.Key, bandAlbum.Value);
            }
        }

        private static ICollection<string> ExtractAllArtistNames(XmlDocument xmlDocument)
        {
            var artistNames = new HashSet<string>();
            var albumsXml = xmlDocument.SelectNodes("/catalog/albums/album");

            foreach (XmlNode album in albumsXml)
            {
                foreach (XmlNode artist in album.SelectNodes("artists/artist"))
                {
                    artistNames.Add(artist.InnerText);
                }
            }

            return artistNames;
        }

        private static IDictionary<string, int> ExtractNumberOfAlbumsForEachBand(XmlDocument xmlDocument)
        {
            var bandsAlbums = new Dictionary<string, int>();
            var albumsXml = xmlDocument.SelectNodes("/catalog/albums/album");

            foreach (XmlNode album in albumsXml)
            {
                var bandName = album.SelectSingleNode("band").InnerText;

                if (!bandsAlbums.ContainsKey(bandName))
                {
                    bandsAlbums[bandName] = 0;
                }

                bandsAlbums[bandName]++;
            }

            return bandsAlbums;
        }
    }
}

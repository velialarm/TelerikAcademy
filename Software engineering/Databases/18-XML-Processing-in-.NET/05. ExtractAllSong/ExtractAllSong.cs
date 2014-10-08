namespace _05.ExtractAllSong
{
    using System;
    using System.Xml;

    /// <summary>
    /// 5. Task
    /// Write a program, which using XmlReaderextracts all song titles from catalog.xml.
    /// </summary>
    public class ExtractAllSong
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("All song titles:\n");

            using (XmlReader reader = XmlReader.Create(@"..\..\catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementContentAsString());
                    }
                }
            }
        }
    }
}

namespace Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Common;
    using Contracts;
    using JsonMapping;

    /// <summary>
    /// All Taks
    /// 
    /// </summary>
    public class Program
    {
        private const string RssFeedUrl = @"http://forums.academy.telerik.com/feed/qa.rss";
        private const string RssFeedFilePath = @"../../rss.txt";
        private const string HtmlPagePath = @"../../index.html";

        public static void Main()
        {
            Console.Write("Loading...");

            DownloadContentFromUrl(RssFeedUrl, RssFeedFilePath);

            var fileContent = FileUtil.GetFileContent(RssFeedFilePath);
            var xml = ConvertStringToXml(fileContent);
            var json = ConvertXmlToJson(xml);

            var questionTitles = SelectAllQuestionTitle(json);
            PrintAllQuestionTitles(questionTitles);

            var pocoObjects = ConvertJsonToPoco(json);

            CreateHtmlPage(pocoObjects);
        }

        private static void DownloadContentFromUrl(string url, string fileName)
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(url, fileName);
            }

            Console.WriteLine("\r-> RSS Feed File was downloaded succesfully...");
        }

        private static XDocument ConvertStringToXml(string text)
        {
            var xml = XDocument.Parse(text);
            return xml;
        }

        /// <summary>
        /// 3. Task
        /// Parse the XML from the feed to JSON4
        /// </summary>
        private static string ConvertXmlToJson(XDocument xml)
        {
            var xmlToJson = JsonConvert.SerializeXNode(xml);
            return xmlToJson;
        }

        private static IList<IArticle> ConvertJsonToPoco(string json)
        {
            var jsonObj = JObject.Parse(json);
            var itemsProjection = jsonObj["rss"]["channel"]["item"];
            var pocoObjects = new List<IArticle>();

            foreach (var item in itemsProjection)
            {
                var deserializedObject = JsonConvert.DeserializeObject<Article>(item.ToString());
                pocoObjects.Add(deserializedObject);
                Console.WriteLine(deserializedObject);
            }

            return pocoObjects;
        }

        /// <summary>
        /// Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question's page
        /// </summary>
        /// <param name="pocoObjects"></param>
        private static void CreateHtmlPage(IList<IArticle> pocoObjects)
        {
            var htmlGenerator = new HtmlGenerator();
            htmlGenerator.CreateHtmlPage(HtmlPagePath, pocoObjects);

            Console.WriteLine("\n-> Html page was created successfully...\n");
        }

        /// <summary>
        /// Using LINQ-to-JSON select all the question titles and print them to the console
        /// </summary>
        private static IEnumerable<object> SelectAllQuestionTitle(string json)
        {
            var jsonObj = JObject.Parse(json);
            var questionTitles = jsonObj["rss"]["channel"]["item"].Select(i => i["title"]);
            return questionTitles;
        }

        private static void PrintAllQuestionTitles(IEnumerable<object> questionTitles)
        {

            foreach (var title in questionTitles)
            {
                Console.WriteLine("- {0}", title);
            }
        }
    }
}
using Json.Contracts;

namespace Json.JsonMapping
{
    using System;
    using Newtonsoft.Json;
    using Json.Contracts;

    public class Article : IArticle
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("pubDate")]
        public DateTime PublishDate { get; set; }

        public override string ToString()
        {
            return string.Format("Article: Title: {0}, PublishDate: {1}", this.Title, this.PublishDate.ToString("dd.MM.yyyy"));
        }
    }
}
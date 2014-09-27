using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.Models
{
    public class Post
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime PostOn { get; set; }

        public string PostedByUser { get; set; }

        public bool IsValidContect()
        {
            return string.IsNullOrEmpty(this.Content);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.Models
{
    public class User
    {
        public User()
        {
//            this.Id = ObjectId.GenerateNewId().ToString();
            this.Name = "Guest";
            this.LoggedTimeFrom = DateTime.Now;
        }

        public User(string name)
        {
//            this.Id = ObjectId.GenerateNewId().ToString();
            this.Name = name;
            this.LoggedTimeFrom = DateTime.Now;
        }

        public User(string name, DateTime loggedFrom)
        {
//            this.Id = ObjectId.GenerateNewId().ToString();
            this.Name = name;
            this.LoggedTimeFrom = loggedFrom;
        }

//        [BsonRepresentation(BsonType.ObjectId)]
//        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime LoggedTimeFrom { get; set; }

        public bool IsValidUser()
        {
            return string.IsNullOrEmpty(this.Name);
        }
    }
}

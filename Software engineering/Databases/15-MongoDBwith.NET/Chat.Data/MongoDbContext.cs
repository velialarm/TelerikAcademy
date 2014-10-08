using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Chat.Data
{
    public class MongoDbContext : MongoDbContextBase
    {

        public MongoDbContext() : base()
        {
            
        }

        public MongoDbContext(string databaseHost, string databaseName)
            : base(databaseHost, databaseName)
        {
            
        }

        public MongoCollection<Post> Posts
        {
            get
            {
                return this.GetCollection<Post>("Posts");
            }
        }

        public MongoCollection<User> Users
        {
            get
            {
                return this.GetCollection<User>("ChatUsers");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Chat.Data
{
    public class MongoDbContextBase
    {
        // TODO move it to app.config
        //private const string DatabaseHostDefault = "mongodb://127.0.0.1"; // local
        private const string DatabaseHostDefault = "mongodb://gusto:maina@ds035270.mongolab.com:35270/vndb"; //remote
        private const string DatabaseNameDefault = "vndb";

        private readonly string databaseHost;
        private readonly string databaseName;
        private MongoServer mongoServer;

        public MongoDbContextBase()
        {
            this.databaseHost = DatabaseHostDefault;
            this.databaseName = DatabaseNameDefault;
        }

        public MongoDbContextBase(string databaseHost, string databaseName)
        {
            this.databaseHost = databaseHost;
            this.databaseName = databaseName;
        }

        protected MongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = this.GetDatabase();
            return database.GetCollection<T>(collectionName);
        }

        private MongoDatabase GetDatabase()
        {
            var server = this.GetServer();
            return server.GetDatabase(this.databaseName);
        }

        private MongoServer GetServer()
        {
            if (this.mongoServer == null)
            {
                var mongoClient = new MongoClient(this.databaseHost);
                this.mongoServer = mongoClient.GetServer();
            }

            return this.mongoServer;
        }
    }
}

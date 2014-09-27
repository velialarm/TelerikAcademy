namespace MongoModule
{
    using System;
    using System.Collections.Generic;
    using Conflux.ContainerData.Expence;
    using MongoDB.Driver;

    public class MongoModuler
    {
        public void ImportDataInMongoDatabase(List<MongoExpense> data)
        {
            MongoClient client = new MongoClient("mongodb://localhost//");
            var server = client.GetServer();
            var db = server.GetDatabase("supermarket");
            var collection = db.GetCollection<MongoExpense>("expenses");

            foreach (var expense in data)
            {
                collection.Insert(expense);
            }
        }

        public void SaveExpence(List<MongoExpense> vendorMongoExpenses)
        {
            //// TODO write loaded xml expence data to mongo database
            throw new NotImplementedException();
        }
    }
}

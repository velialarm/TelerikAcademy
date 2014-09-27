namespace Conflux.ContainerData.Expence
{
    using System;
    using MongoDB.Bson;

    public class MongoExpense
    {
        public BsonObjectId Id { get; set; }

        public DateTime Month { get; set; }

        public decimal Value { get; set; }

        public string VendorName { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Value: {1}, Month: {2}, VendorName: {3}", this.Id, this.Value, this.Month, this.VendorName);
        }
    }
}

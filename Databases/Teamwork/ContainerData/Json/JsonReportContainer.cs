﻿namespace Conflux.ContainerData.Json
{
    using System.Text;
    using MongoDB.Bson;

    public class JsonReportContainer
    {
        public BsonObjectId Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string VendorName { get; set; }

        public int TotalQuntitySold { get; set; }

        public decimal TotalIncome { get; set; }

        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"ProductId\" : " + this.ProductId + ",");
            sb.Append("\"ProductName\" : \"" + this.ProductName + "\",");
            sb.Append("\"VendorName\" : \"" + this.VendorName + "\",");
            sb.Append("\"TotalQuntitySold\" : " + this.TotalQuntitySold + ",");
            sb.Append("\"TotalIncome\" : " + this.TotalIncome);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

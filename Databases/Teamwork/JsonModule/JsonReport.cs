using Conflux.Data;

namespace JsonModule
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using MondoDbProvider;
    using Conflux.ContainerData.Json;

    public class JsonReport
    {
        public void Generate(List<JsonReportContainer> data)
        {
            MongoJsonWriter.SetInitialData(@"mongodb://localhost", "twjsonreports", "reports");
            MongoJsonWriter.EstablishConnection();
            Directory.CreateDirectory(@"..\..\Product-Reports");
            foreach (var item in data)
            {
                MongoJsonWriter.SaveJson(item.ToJson());
                var strWriter = File.AppendText(@"..\..\Product-Reports\" + item.ProductId + ".json");
                using (strWriter)
                {
                    strWriter.WriteLine(item.ToJson());
                }
            }
        }


        public string GetReportAsJsonArray(List<JsonReportContainer> jsonReportContainers)
        {
            if (jsonReportContainers.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var report in jsonReportContainers)
            {
                sb.Append(report.ToJson() + ", ");
            }

            sb.Length -= 2;
            sb.Append("]");

            return sb.ToString();
        }

        public void SaveToFile(string jsong, string filename)
        {
            //TODO Improvement -> create save to fale  - new feature
            throw new NotImplementedException();
        }

    }
}

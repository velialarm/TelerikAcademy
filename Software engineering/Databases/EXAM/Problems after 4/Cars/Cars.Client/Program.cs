namespace Cars.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Cars.Data;
    using Cars.Model;
    using Newtonsoft.Json;

    public class Program
    {
        private const string JsonFilePath = @"..\..\..\data.number.json";
        private const string XmlQueryPath = @"..\..\..\queries.xml";

        private static CarsContext db;

        public static void Main()
        {
            db = new CarsContext();

            //// Problem 6. Parse json file and insert data to databse
            ImportJsonData(JsonFilePath);

            ////Problem 7 - Application Queries 
            GenerateResultByQueryXML(XmlQueryPath);
        }

        public static void GenerateResultByQueryXML(string pathFile)
        {
            Console.WriteLine("Starting create query result in xml files");
            var queryDocument = XElement.Load(pathFile);
            var xmlQueries = queryDocument.Elements("Query");

            foreach (var xmlQuery in xmlQueries)
            {
                var queryResult = db.Cars.AsQueryable();

                var xmlOutputFile = xmlQuery.Attribute("OutputFileName");
                var filePathForQuery = string.Empty;
                if (xmlOutputFile != null)
                {
                    filePathForQuery = xmlOutputFile.Value;
                }
                else
                {
                    Console.WriteLine("Cannot found output file name for result");
                    continue;
                }

                foreach (var xmlWhereClause in xmlQuery.Elements("WhereClauses"))
                {
                    var xmlWhereElement = xmlWhereClause.Element("WhereClause");
                    var xmlPropertyName = xmlWhereElement.Attribute("PropertyName");

                    var xmlType = xmlWhereElement.Attribute("Type");
                    var whereValue = xmlWhereElement.Value;
                    if (xmlPropertyName != null && xmlType != null)
                    {
                        var propertyName = xmlPropertyName.Value;
                        var type = xmlType.Value;

                        if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(type))
                        {
                            Console.WriteLine("PropertyName or Type cannot be empty or null");
                            continue;
                        }

                        ////must change operator == with type
                        switch (type)
                        {
                            case "Id":
                                queryResult = queryResult.Where(c => c.Id == int.Parse(propertyName));
                                break;
                            case "Year":
                                queryResult = queryResult.Where(c => c.Year == propertyName);
                                break;
                            case "Price":
                                queryResult = queryResult.Where(c => c.Price == decimal.Parse(propertyName));
                                break;
                            case "Model":
                                queryResult = queryResult.Where(c => c.Model == propertyName);
                                break;
                            case "Manufacturer":
                                queryResult = queryResult.Where(c => c.Manufacturer.Name == propertyName);
                                break;
                            case "Dealer":
                                queryResult = queryResult.Where(c => c.Dealer.Name == propertyName);
                                break;
                            case "City":
                                queryResult = queryResult.Where(c => c.Dealer.Cities.Select(a => a.Name).Contains(propertyName));
                                break;
                        }
                    }
                }

                var xmlOrderBy = xmlQuery.Element("OrderBy");
                if (xmlOrderBy != null)
                {
                    var order = xmlOrderBy.Value;
                    switch (order)
                    {
                        case "Id":
                            queryResult = queryResult.OrderBy(c => c.Id);
                            break;
                        case "Year":
                            queryResult = queryResult.OrderBy(c => c.Year);
                            break;
                        case "Price":
                            queryResult = queryResult.OrderBy(c => c.Price);
                            break;
                        case "Model":
                            queryResult = queryResult.OrderBy(c => c.Model);
                            break;
                        case "Manufacturer":
                            queryResult = queryResult.OrderBy(c => c.Manufacturer.Name);
                            break;
                        case "Dealer":
                            queryResult = queryResult.OrderBy(c => c.Dealer.Name);
                            break;
                        case "City":
                            queryResult = queryResult.OrderBy(c => c.Dealer.Cities.Select(a => a.Name));
                            break;
                    }
                }

                var resultList = queryResult.Select(c => c).ToList();

                // Write Result for each query to file
                var resultFile = new XElement("Cars");
                foreach (var car in queryResult)
                {
                    var xmlCarElement = new XElement("Car");
                    xmlCarElement.Add(new XElement("TransmissionType"));

                    var xmlDealerElement = new XElement("Dealer");
                    var xmlCytiesEl = new XElement("Cities");
                    foreach (var car1 in car.Dealer.Cities)
                    {
                        var xmlCity = new XElement("City");
                    }

                    xmlDealerElement.Add(xmlCytiesEl);
                    xmlCarElement.Add(xmlDealerElement);

                    xmlCarElement.Add(new XElement("TransmissionType"));

                    resultFile.Add(xmlCarElement);

                    resultFile.Save(filePathForQuery);
                }

                Console.WriteLine("query result ended.");
            }
        }

        public static void ImportJsonData(string jsonFilePath)
        {
            Console.WriteLine("Starting imported json data");

            string fileContent = FileUtil.GetFileContent(jsonFilePath).Trim();
            var carsData = JsonConvert.DeserializeObject<List<CarContainer>>(fileContent);

            var index = 1;
            foreach (var carData in carsData)
            {
                var car = new Car
                {
                    Model = carData.Model,
                    Price = carData.Price,
                    TransmisionType = carData.TransmissionType == "0" ? TransmisionType.Automatic : TransmisionType.Manual,
                    Year = carData.Year
                };

                // add manufucter 
                string manufacturerName = carData.ManufacturerName;
                var manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
                if (manufacturer == null)
                {
                    manufacturer = new Manufacturer
                    {
                        Name = manufacturerName
                    };
                }

                car.Manufacturer = manufacturer;

                // add city
                var cityName = carData.Dealer.City;
                var city = db.Cities.FirstOrDefault(c => c.Name == cityName);
                if (city == null)
                {
                    city = new City
                    {
                        Name = cityName
                    };
                }

                //// add  dealer 
                string dealerName = carData.Dealer.Name;
                var dealer = db.Dealers.FirstOrDefault(d => d.Name == dealerName);
                if (dealer == null)
                {
                    dealer = new Dealer()
                    {
                        Name = dealerName
                    };
                }

                if (!dealer.Cities.Contains(city))
                {
                    dealer.Cities.Add(city);
                }

                car.Dealer = dealer;

                db.Cars.Add(car);

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                }

                index++;
            }

            db.SaveChanges();
            Console.WriteLine("Json data was imported");
        }
    }
}

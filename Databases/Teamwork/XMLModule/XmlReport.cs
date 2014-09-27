using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Conflux.ContainerData.Expence;

namespace XMLModule
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Conflux.Data;

    public class XmlReport
    {
        public List<MongoExpense> GetVendorMongoExpenses(string xmlFilePath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);

            List<MongoExpense> expenses = new List<MongoExpense>();
            XmlNode sales = document.DocumentElement;
            foreach (XmlNode sale in sales.ChildNodes)
            {
                foreach (XmlNode expense in sale.ChildNodes)
                {
                    DateTime date = DateTime.ParseExact(expense.Attributes[0].Value, "MMM-yyyy", CultureInfo.InvariantCulture);
                    string vendorName = sale.Attributes[0].Value;

                    var currentExpense = new MongoExpense
                    {
                        Month = date,
                        Value = decimal.Parse(expense.InnerText),
                        VendorName = vendorName
                    };

                    expenses.Add(currentExpense);
                }
            }

            return expenses;
        }

        public bool Generate(string name)
        {
            using (var db = new ConfluxEntities())
            {
                try
                {
                    XDocument xmlDocument = new XDocument(
                        new XDeclaration("1.0", "utf-8", "no"),
                        new XProcessingInstruction("xml-stylesheet", @"type=""text/xsl"" href=""SalesStyle.xslt"""));
                    var vendors = from vendor in db.Vendors select vendor;
                    var vendorByName = vendors.GroupBy(x => x.VendorName);
                    var sale = new XElement("Sales");
                    xmlDocument.Add(sale);
                    foreach (var item in vendorByName)
                    {
                        var secondSale = new XElement("sale");
                        sale.Add(secondSale);
                        var vendor = new XAttribute("vendor", item.Key);
                        secondSale.Add(vendor);
                        foreach (var date in item)
                        {
                            //// TODO Get date for sum of price  and  calculate total sum 
                            secondSale.Add(
                                new XElement(
                                    "summary", 
                                    new XAttribute("date", "date"), //TODO mus implemetn date
                                    new XAttribute("total-sum", "price"))); //TODO must implement price
                        }
                    }

                    xmlDocument.Save(name);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error when generate xml report! Error: {0}", e.InnerException.Message);
                    return false;
                }

                ///return true for succesfull operation... 
                return true;
            }
        }
    }
}

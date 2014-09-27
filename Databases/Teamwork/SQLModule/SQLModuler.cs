using Conflux.ContainerData.Expence;
using Conflux.ContainerData.Json;

namespace SQLModule
{
    using System.Collections.Generic;
    using System.Linq;
    using Conflux.ContainerData.PdfExport;
    using Conflux.Data;
    using Conflux.Model;

    public class SQLModuler
    {
        public List<PdfExportContainer> LoadPdfExportData()
        {
            List<PdfExportContainer> result = new List<PdfExportContainer>();
            using (var db = new ConfluxEntities())
            {
                List<Product> products = db.Products.OrderBy(b => b.CreatedDate).ToList();
                foreach (var product in products)
                {
                    PdfExportContainer containerData = new PdfExportContainer();
                    containerData.Location = product.Vendor.VendorName;
                    containerData.Date = product.CreatedDate;
                    containerData.Measure = product.Measure.MeasureName;
                    containerData.ProductName = product.ProductName; 
                    containerData.Quantity = (int)product.Quantity;
                    containerData.Price = (decimal)product.Proce;
                    result.Add(containerData);
                }
            }

            return result;
        }

        public List<JsonReportContainer> GetJsonReports()
        {
            List<JsonReportContainer> result = new List<JsonReportContainer>();
            using (var db = new ConfluxEntities())
            {
                // TODO 
                //                var jsonReports = from p in db.Products
                //                                  join dr in db.DailyReports on p.Id equals dr.ProductId
                //                                  join v in db.Vendors on p.VendorId equals v.Id
                //                                  select new JSonReport
                //                                  {
                //                                      ProductId = p.Id,
                //                                      ProductName = p.ProductName,
                //                                      VendorName = v.VendorName,
                //                                      TotalQuntitySold = dr.Quantity,
                //                                      TotalIncome = dr.Quantity * dr.Price
                //                                  };
                //
                //                return jsonReports.ToList();
            }

            return result;
        }

        public void SaveExpence(List<MongoExpense> vendorMongoExpenses)
        {
            //TODO write loaded xml expence data to SQL SERVER
            throw new System.NotImplementedException();
        }
    }
}

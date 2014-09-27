namespace SQLModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Conflux.ContainerData.ZipContainer;
    using Conflux.Data;
    using Conflux.Model;

    public class ImportProduct
    {
        public bool SaveExcelReport(List<ZipExcelContainer> data)
        {
            using (var db = new ConfluxEntities())
            {
                foreach (var excelData in data)
                {
                    foreach (var productData in excelData.Products)
                    {
                        var product = new Product();
                        Currency currency = db.Currencies.FirstOrDefault();
                        if (currency == null)
                        {
                            currency = db.Currencies.Add(new Currency() { Name = "EURO" });
                            db.SaveChanges();
                        }

                        product.Currency = currency;

                        Measure measure = db.Measures.FirstOrDefault();
                        if (measure == null)
                        {
                            measure = db.Measures.Add(new Measure() { MeasureName = "Qty." });
                            db.SaveChanges();
                        }

                        product.Measure = measure;

                        Vendor vendor = db.Vendors.Where(b => b.VendorName == excelData.FileName.Trim()).FirstOrDefault();
                        if (vendor == null)
                        {
                            vendor = new Vendor();
                            vendor.VendorName = excelData.FileName.Trim();
                            Town town = db.Towns.FirstOrDefault();
                            if (town == null)
                            {
                                town = db.Towns.Add(new Town() { TownName = "MainaTown" });
                                db.SaveChanges();
                            }

                            vendor.Town = town;
                            VendorType vendorType = db.VendorTypes.FirstOrDefault();
                            if (vendorType == null)
                            {
                                vendorType = db.VendorTypes.Add(new VendorType() { Name = "BeerFactory" });
                                db.SaveChanges();
                            }

                            vendor.VendorType = vendorType;
                            db.Vendors.Add(vendor);
                            db.SaveChanges();
                        }

                        product.Vendor = vendor;

                        // product.Name = ""; // ?????
                        product.Id = productData.ProductID;
                        product.CreatedDate = excelData.Date;
                        product.Proce = (float)productData.UnitPrice;
                        product.Quantity = productData.Quantity;
                        db.Products.Add(product);
                    }
                }

                db.SaveChanges();
            }

            return false;
        }
    }
}

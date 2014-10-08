namespace ClientModule
{
    using System.Collections.Generic;
    using Conflux.ContainerData.Expence;
    using Conflux.ContainerData.PdfExport;
    using Conflux.ContainerData.ZipContainer;
    using Conflux.Report;
    using MongoModule;
    using PDFModule;
    using SQLModule;
    using XMLModule;
    using Conflux.ContainerData.Json;
    using JsonModule;
    using MySQLModule;

    public class StartupClient
    {
        public static void Main()
        {
            //// 1. TASK ZIP MODULE TEST - 1 task - Load Excel Reports from ZIP File
            //// !!!!!!!!!!!!!! file must be in ClientModule/bin/Debug folder or set full path  !!!!!!!!!!!!!!

            string zipFileDemopath = @"Sample-Sales-Reports.zip";  
            ZipReader zipReader = new ZipReader(zipFileDemopath);
            List<ZipExcelContainer> zipResult = zipReader.FetchData();
            ImportProduct importZipData = new ImportProduct();
            importZipData.SaveExcelReport(zipResult);

            //// 2. TASK PDF MODULE TEST - 2 task
            SQLModuler sqlModuler = new SQLModuler();
            List<PdfExportContainer> loadPdfExportData = sqlModuler.LoadPdfExportData();
            PDFModuler pdfModule = new PDFModuler();
            string pathToSavePdf = @"export.pdf";
            pdfModule.Export(loadPdfExportData, pathToSavePdf);

            ////3 task - Generate XML Sales Report by Vendors
            XmlReport xlmReport = new XmlReport();
            xlmReport.Generate("xmlReport.xml");

            //// 4. Task - Generate JSON Reports
            SQLModuler sqlModulerForJsonReport = new SQLModuler();
            List<JsonReportContainer> jsonReportContainers = sqlModulerForJsonReport.GetJsonReports();
            JsonReport jsonReport = new JsonReport();
             jsonReport.Generate(jsonReportContainers);
            string reportAsJsonArray = jsonReport.GetReportAsJsonArray(jsonReportContainers); 
            MySQLModuler mySql = new MySQLModuler();
            //mySql.SaveJson(reportAsJsonArray); //// TODO implement before uncomment
            //// jsonReport.SaveToFile(reportAsJsonArray, "jsonReport.txt"); // feature

            //// 5. Task  - Load data from XML - read the XML file, parse it and save the data in the MongoDB database and in the SQL Server
            string mongoDatabaseFileName = @"Sample-Vendors-Expenses.xml";
            XmlReport xmlReport = new XmlReport();
            List<MongoExpense> vendorMongoExpenses = xmlReport.GetVendorMongoExpenses(mongoDatabaseFileName);
            MongoModuler mongo = new MongoModuler();
            //mongo.SaveExpence(vendorMongoExpenses); //// TODO implement before uncomment
            SQLModuler sqMod = new SQLModuler();
            //sqMod.SaveExpence(vendorMongoExpenses); //// TODO implement before uncomment

            //// 6. Task  - Read the MySQL database of reports, read the information from SQLite and generate a single Excel 2007 file holding some information by your choice
            ////TODO must implement
        }
    }
}

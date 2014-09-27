namespace Conflux.Report
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using ContainerData.ZipContainer;
    using ExcelModule;
    using Ionic.Zip;

    public class ZipReader
    {
        private const string TempFolderName = "tempZipExctracted";

        public ZipReader(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; private set; }

        public List<ZipExcelContainer> FetchData()
        {
            ZipFile archive = this.ReadZipArhiv();
            string tempFolder = Directory.GetCurrentDirectory() + "\\" + TempFolderName + DateTime.Now.ToString("yyyymmhhmmss");

            //// extract data to temporary folder
            using (archive)
            {
                Directory.CreateDirectory(tempFolder);
                foreach (var item in archive.Entries)
                {
                    var archiveFileName = Path.GetFileName(item.ToString());
                    if (archiveFileName.Length != 0)
                    {
                        item.Extract(tempFolder);
                    }
                }
            }

            //// read data from files in temporary folder
            var excelFiles = Directory.GetFileSystemEntries(tempFolder, "*.xls", SearchOption.AllDirectories);
            List<ZipExcelContainer> result = new List<ZipExcelContainer>();
            foreach (var file in excelFiles)
            {
                var excelReader = new ExcelReader(file);
                var row = excelReader.GetAllEntriesReader();

                bool isHeader = true;
                string marketName = string.Empty;
                string reportDate = this.GetDateFromFileName(file);
                DateTime date = DateTime.Parse(reportDate);
                using (excelReader)
                {
                    ZipExcelContainer zipContainer = new ZipExcelContainer(date);
                    while (row.Read())
                    {
                        if (isHeader)
                        {
                            marketName = (string)row[0];
                            zipContainer.FileName = marketName;
                            isHeader = false;
                            continue;
                        }

                        var productIdStr = string.Empty;
                        var priceStr = string.Empty;
                        var quantityStr = string.Empty;
                        if (row[0] != DBNull.Value && row[1] != DBNull.Value && row[2] != DBNull.Value)
                        {
                            productIdStr = row[0].ToString();
                            quantityStr = row[1].ToString();
                            priceStr = row[2].ToString();
                            ZipExcelProductContainer excelProductData = new ZipExcelProductContainer(int.Parse(productIdStr), int.Parse(quantityStr), decimal.Parse(priceStr));
                            zipContainer.Products.Add(excelProductData);
                        }
                    }

                    result.Add(zipContainer);
                }
            }

            //// delete in temporary folder all extracted data
            this.DeleteTemporaryFolder(tempFolder);

            return result;
        }

        private ZipFile ReadZipArhiv()
        {
            try
            {
                return ZipFile.Read(this.FilePath);
            }
            catch (Exception)
            {
                throw new ArgumentException("Cannot read zip file or path is invalid");
            }
        }

        private void DeleteTemporaryFolder(string teporaryFolder)
        {
            var currentTempDir = Directory.GetFileSystemEntries(teporaryFolder, "*.xls", SearchOption.AllDirectories);

            foreach (var file in currentTempDir)
            {
                File.Delete(file);
            }

            Directory.Delete(teporaryFolder, true);
        }

        private string GetDateFromFileName(string filename)
        {
            string directory = Path.GetDirectoryName(filename);
            var index = directory.LastIndexOf('\\') + 1;
            var date = directory.Substring(index);
            return date;
        }
    }
}

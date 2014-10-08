namespace ExcelModule
{
    using System;
    using System.Data.OleDb;

    public class ExcelReader : IDisposable
    {
        private OleDbConnection excelConnection;

        public ExcelReader(string filePath)
        {
            this.ExcelConnectionString =
            string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\";", filePath);
            this.EstablishConnection();
        }

        public string ExcelConnectionString { get; private set; }

        public OleDbDataReader GetAllEntriesReader()
        {
            string getAllEntriesQuery = @"SELECT * FROM [Sales$]";
            OleDbCommand getInformation = new OleDbCommand(getAllEntriesQuery, this.excelConnection);
            OleDbDataReader infoReader = getInformation.ExecuteReader();

            return infoReader;
        }

        public void Dispose()
        {
            this.excelConnection.Close();
        }

        private void EstablishConnection()
        {
            this.excelConnection = new OleDbConnection(this.ExcelConnectionString);
            this.excelConnection.Open();
        }
    }
}

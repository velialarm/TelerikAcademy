namespace Conflux.ContainerData.PdfExport
{
    using System;

    public class PdfExportContainer
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string Measure { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }
    }
}

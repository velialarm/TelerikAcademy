namespace Conflux.ContainerData.ZipContainer
{
    using System;
    using System.Collections.Generic;

    public class ZipExcelContainer
    {
        public ZipExcelContainer(DateTime date)
        {
            this.Date = date;
            this.Products = new List<ZipExcelProductContainer>();
        }

        public string FileName { get; set; }

        public DateTime Date { get; set; }

        public List<ZipExcelProductContainer> Products { get; set; }
    }
}

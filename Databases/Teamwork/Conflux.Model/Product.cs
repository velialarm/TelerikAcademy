namespace Conflux.Model
{
    using System;

    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public float Proce { get; set; }

        public float Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}

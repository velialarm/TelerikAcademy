namespace Conflux.Model
{
    using System.Collections.Generic;

    public class Vendor
    {
        private ICollection<Product> products;

        public Vendor()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string VendorName { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public int VendorTypeId { get; set; }

        public virtual VendorType VendorType { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}

namespace Conflux.Model
{
    using System.Collections.Generic;

    public class VendorType
    {
        private ICollection<Vendor> vendors;

        public VendorType()
        {
            this.vendors = new HashSet<Vendor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Vendor> Vendors
        {
            get { return this.vendors; }
            set { this.vendors = value; }
        }
    }
}

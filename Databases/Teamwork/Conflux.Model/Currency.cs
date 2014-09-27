namespace Conflux.Model
{
    using System.Collections.Generic;

    public class Currency
    {
        private ICollection<Product> products;

        public Currency()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}

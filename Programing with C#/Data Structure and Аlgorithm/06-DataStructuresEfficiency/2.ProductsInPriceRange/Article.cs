namespace DataStructureEfficiency
{
    using System;

    public class Article : IComparable<Article>
    {
        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public string Vendor { get; private set; }

        public string Barcode { get; private set; }

        public Article(string title, decimal price, string vendor, string barcode = "0")
        {
            this.Title = title;
            this.Price = price;
            this.Vendor = vendor;
            this.Barcode = barcode;
        }

        public int CompareTo(Article other)
        {
            return string.Compare(this.Title, other.Title);
        }

        public override string ToString()
        {
            return string.Join("; ",
                "Price: " + this.Price,
                "Title: " + this.Title,
                "Vendor: " + this.Vendor,
                "Barcode: " + this.Barcode
                );
        }
    }
}
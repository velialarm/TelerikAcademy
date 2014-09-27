namespace Conflux.ContainerData.ZipContainer
{
    public class ZipExcelProductContainer
    {
        public ZipExcelProductContainer(int productId, int quantity, decimal price)
        {
            this.ProductID = productId;
            this.Quantity = quantity;
            this.UnitPrice = price;
        }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal GetSum()
        {
            return this.Quantity * this.UnitPrice;
        }
    }
}
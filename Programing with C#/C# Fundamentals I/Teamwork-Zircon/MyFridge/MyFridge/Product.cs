using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public abstract class Product : IVegetarian
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullOrWhitespaceException("Product's name cannot be null or empty string!");
                }
                this.name = value;
            }
        }
        public BaseUnit BaseUnit { get; set; }
        public ShoppingUnit ShoppingUnit { get; set; }
        public decimal PricePerShoppingUnit { get; set; }

        protected Product(string name, BaseUnit measure, bool isVegetarian, FoodType type, ShoppingUnit unit, decimal price)
        {
            this.Name = name;
            this.BaseUnit = measure;
            this.IsVegetarian = isVegetarian;
            this.ShoppingUnit = unit;
            this.PricePerShoppingUnit = price;
            this.FoodType = type;
        }

        public bool IsVegetarian { get; set; }

        public FoodType FoodType { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", this.GetType().Name, this.Name, this.BaseUnit, this.IsVegetarian, this.ShoppingUnit);
        }
    }
}

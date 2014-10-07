using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class ProductFlyweightFactory
    {
        private IDictionary<string, Product> availableProducts;

        public static ProductFlyweightFactory Factory { get; private set; }

        static ProductFlyweightFactory()
        {
            Factory = new ProductFlyweightFactory();
        }

        private ProductFlyweightFactory()
        {
            availableProducts = new Dictionary<string, Product>();
        }

        private Product Produce(string[] productData)
        {
            switch (productData[0])
            {
                case "FruitVegetable":
                    return new FruitVegetable(productData[1], decimal.Parse(productData[2]));
                case "MeatFish":
                    return new MeatFish(productData[1], decimal.Parse(productData[2]));
                case "Egg":
                    return new Egg(decimal.Parse(productData[2]));
                case "Nut":
                    return new Nut(productData[1], decimal.Parse(productData[2]));
                case "Dairy":
                    return new Dairy(productData[1], new ShoppingUnit((ShoppingPackage)int.Parse(productData[2]), int.Parse(productData[3])), decimal.Parse(productData[4]));
                case "Beverage":
                    return new Beverage(productData[1], double.Parse(productData[2]), decimal.Parse(productData[3]));
                case "LiquidFat":
                    return new LiquidFat(productData[1], double.Parse(productData[2]), decimal.Parse(productData[3]));
                case "Cereal":
                    return new Cereal(productData[1], int.Parse(productData[2]), decimal.Parse(productData[3]));
                case "Legume":
                    return new Legume(productData[1], int.Parse(productData[2]), decimal.Parse(productData[3]));
                case "Spice":
                    return new Spice(productData[1], int.Parse(productData[2]), decimal.Parse(productData[3]));
                default:
                    throw new ArgumentException();
            }
        }

        public Product MakeProduct(string name, string[] productData)
        {
            Product requestedProduct;
            if (!availableProducts.ContainsKey(name))
            {
                requestedProduct = Produce(productData);
                availableProducts.Add(name, requestedProduct);
            }
            else
            {
                requestedProduct = availableProducts[name];
            }

            return requestedProduct;
        }

        public IEnumerable<Product> GetAvailableProducts()
        {
            return availableProducts.Values;
        }
    }
}

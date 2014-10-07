using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class ShoppingList : ICalculable, IEnumerable<KeyValuePair<Product, int>>, IDictionary<Product, int> 
    {
        private Dictionary<Product, int> ToBuyList { get; set; }

        public static ShoppingList MyShoppingList;

        static ShoppingList()
        {
            MyShoppingList = new ShoppingList();
        }

        private ShoppingList()
        {
            this.ToBuyList = new Dictionary<Product, int>();
            Refrigerator.MyFridge.Changed += new ChangedFridgeEventHandler(GenerateShoppingList);
            WeekMenu.MyMenu.Changed += new ChangedWeekMenuEventHandler(GenerateShoppingList);
        }

        public void Add(Product product, int quantity)
        {
            if (this.ToBuyList.ContainsKey(product))
            {
                this.ToBuyList[product] += quantity;
            }
            else
            {
                this.ToBuyList.Add(product, quantity);
            }
        }

        public void Clear()
        {
            this.ToBuyList.Clear();
        }

        public void Remove(Product product)
        {
            if (this.ToBuyList.ContainsKey(product))
            {
                this.ToBuyList.Remove(product);
            }
            else
            {
                throw new ArgumentException("Unable to remove the product - there is not such product in the collection.");
            }
        }

        public decimal GetTotalValue()
        {
            return this.ToBuyList.Sum(i => i.Key.PricePerShoppingUnit * Math.Ceiling((decimal)i.Value / i.Key.ShoppingUnit.BaseUnitsPerPackage));
        }

        public override string ToString()
        {
            StringBuilder outputText = new StringBuilder();
            foreach (var product in ShoppingList.MyShoppingList.ToBuyList.OrderBy(p => p.Key.FoodType).ThenBy(p => p.Key.Name))
            {
                outputText.AppendFormat("{0} {1} {2} {3:0.00} BGN{4}", product.Key.Name,
                                                 Math.Ceiling((decimal)product.Value / product.Key.ShoppingUnit.BaseUnitsPerPackage),
                                                 product.Key.ShoppingUnit.PackageType,
                                                 product.Key.PricePerShoppingUnit * Math.Ceiling((decimal)product.Value / product.Key.ShoppingUnit.BaseUnitsPerPackage),
                                                 Environment.NewLine);
            }
            outputText.AppendFormat("{0}{1}", new string('-', 25), Environment.NewLine);
            outputText.AppendFormat("Total Value: {0:0.00} BGN", ShoppingList.MyShoppingList.GetTotalValue());

            return outputText.ToString();
        }

        private void GenerateShoppingList(object sender, EventArgs e)
        {
            this.ToBuyList.Clear();
            foreach (var meal in WeekMenu.MyMenu)
            {
                foreach (var ingredient in meal.Key)
                {
                    if (this.ToBuyList.ContainsKey(ingredient.Key))
                    {
                        this.ToBuyList[ingredient.Key] += ingredient.Value * meal.Value;
                    }
                    else if (ingredient.Value * meal.Value > 0)
                    {
                        this.ToBuyList.Add(ingredient.Key, ingredient.Value * meal.Value);
                    }
                }
            }
            foreach (var item in Refrigerator.MyFridge)
            {
                if (this.ToBuyList.ContainsKey(item.Key) && this.ToBuyList[item.Key] > item.Value)
                {
                    this.ToBuyList[item.Key] -= item.Value;
                }
                else
                {
                    this.ToBuyList.Remove(item.Key);
                }
            }
        }

        public bool ContainsKey(Product key)
        {
            return this.ToBuyList.ContainsKey(key);
        }

        public ICollection<Product> Keys
        {
            get { return this.ToBuyList.Keys; }
        }

        bool IDictionary<Product, int>.Remove(Product key)
        {
            return this.ToBuyList.Remove(key);
        }

        public bool TryGetValue(Product key, out int value)
        {
            return this.ToBuyList.TryGetValue(key, out value);
        }

        public ICollection<int> Values
        {
            get { return this.ToBuyList.Values; }
        }

        public int this[Product key]
        {
            get
            {
                if (this.ToBuyList.ContainsKey(key))
                {
                    return this.ToBuyList[key];
                }
                else
                {
                    throw new ArgumentException("There isn't such product in the shopping list.");
                }
            }
            set
            {
                this.ToBuyList[key] = value;
            }
        }

        public void Add(KeyValuePair<Product, int> item)
        {
            this.ToBuyList.Add(item.Key, item.Value);
        }

        public bool Contains(KeyValuePair<Product, int> item)
        {
            return this.ToBuyList.Contains(item);
        }

        public void CopyTo(KeyValuePair<Product, int>[] array, int arrayIndex)
        {
        }

        public int Count
        {
            get { return this.ToBuyList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<Product, int> item)
        {
            return this.ToBuyList.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<Product, int>> GetEnumerator()
        {
            return this.ToBuyList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.ToBuyList.GetEnumerator();
        }

    }
}

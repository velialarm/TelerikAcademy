using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class Meal : ICalculable, IVegetarian, IFoodType, IEnumerable<KeyValuePair<Product, int>>, IDictionary<Product, int>
    {
        private string name;

        private Dictionary<Product, int> Ingredients { get; set; }

        public MealType MealType { get; set; }
       
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
                    throw new ArgumentNullOrWhitespaceException("Meal's name cannot be null or empty string!");
                }
                this.name = value;
            }
        }

        public Meal(string name, MealType mealType)
        {
            this.Ingredients = new Dictionary<Product, int>();
            this.Name = name;
            this.MealType = mealType;
        }

        public void Add(Product product, int quantity)
        {
            if (this.Ingredients.ContainsKey(product))
            {
                this.Ingredients[product] += quantity;
            }
            else
            {
                this.Ingredients.Add(product, quantity);
            }
        }

        public void Clear()
        {
            this.Ingredients.Clear();
        }

        public void Remove(Product product)
        {
            if (this.Ingredients.ContainsKey(product))
            {
                this.Ingredients.Remove(product);
            }
            else
            {
                throw new ArgumentException("Unable to remove the product - there isn't such product in the collection.");
            }
        }

        public decimal GetTotalValue()
        {
            return this.Ingredients.Sum(i => i.Key.PricePerShoppingUnit / i.Key.ShoppingUnit.BaseUnitsPerPackage * i.Value);
        }

        public bool IsVegetarian 
        {
            get
            {
                return !this.Ingredients.Any(i => !(i.Key.IsVegetarian));
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} {1}{2}", this.GetType().Name, this.Name, Environment.NewLine);
            foreach (var ingredient in this.Ingredients)
            {
                output.AppendFormat("{0} {1}{2}", ingredient.Key.Name, ingredient.Value, Environment.NewLine);
            }
            output.Remove(output.Length - 1, 1);
            return output.ToString();
        }

        public bool ContainsKey(Product key)
        {
            return this.Ingredients.ContainsKey(key);
        }

        public ICollection<Product> Keys
        {
            get { return this.Ingredients.Keys; }
        }

        bool IDictionary<Product, int>.Remove(Product key)
        {
            return this.Ingredients.Remove(key);
        }

        public bool TryGetValue(Product key, out int value)
        {
            return this.Ingredients.TryGetValue(key, out value);
        }

        public ICollection<int> Values
        {
            get { return this.Ingredients.Values; }
        }
    
        public int this[Product key]
        {
            get
            {
                if (this.Ingredients.ContainsKey(key))
                {
                    return this.Ingredients[key];
                }
                else
                {
                    throw new ArgumentException("There isn't such ingredient in the meal.");
                }
            }
            set
            {
                this.Ingredients[key] = value;
            }
        }

        public void Add(KeyValuePair<Product, int> item)
        {
            this.Ingredients.Add(item.Key, item.Value);
        }

        public bool Contains(KeyValuePair<Product, int> item)
        {
            return this.Ingredients.Contains(item);
        }

        public void CopyTo(KeyValuePair<Product, int>[] array, int arrayIndex)
        {
        }

        public int Count
        {
            get { return this.Ingredients.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<Product, int> item)
        {
            return this.Ingredients.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<Product, int>> GetEnumerator()
        {
            return this.Ingredients.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Ingredients.GetEnumerator();
        }

        public Dictionary<FoodType, int> GetFoodTypeDistribution()
        {
            var result = new Dictionary<FoodType, int>();
            foreach (var ingredient in this)
            {
                if(result.ContainsKey(ingredient.Key.FoodType))
                {
                    result[ingredient.Key.FoodType] += ingredient.Value;
                }
                else
                {
                    result.Add(ingredient.Key.FoodType, ingredient.Value);
                }
            }
            return result;
        }
    }
}

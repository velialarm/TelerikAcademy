
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge //TODO: FoodTypes
{
    public delegate void ChangedFridgeEventHandler(object sender, EventArgs e);

    public class Refrigerator : IEnumerable<KeyValuePair<Product, int>>, IDictionary<Product, int>
    {
        public event ChangedFridgeEventHandler Changed;

        public static Refrigerator MyFridge { get; set; }

        private Dictionary<Product, int> InStock { get; set; }

        static Refrigerator()
        {
            MyFridge = new Refrigerator();
        }

        private Refrigerator()
        {
            this.InStock = new Dictionary<Product, int>();
        }

        private void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public void Add(Product product, int quantity)
        {
            if (this.InStock.ContainsKey(product))
            {
                this.InStock[product] += quantity;
            }
            else
            {
                this.InStock.Add(product, quantity);
            }
            OnChanged(EventArgs.Empty);
        }

        public void Clear()
        {
            this.InStock.Clear();
            OnChanged(EventArgs.Empty);
        }

        public void Remove(Product product)
        {
            if (this.InStock.ContainsKey(product))
            {
                this.InStock.Remove(product);
            }
            else
            {
                throw new ArgumentException("Unable to remove the product - no such product in fridge.");
            }
            OnChanged(EventArgs.Empty);
        }

        public int this[Product index]
        {
            get
            {
                if(this.InStock.ContainsKey(index))
                {
                    return this.InStock[index];
                }
                else
                {
                    throw new ArgumentException("No such product in fridge.");
                }
            }
            set 
             {
                this.InStock[index] = value;
                OnChanged(EventArgs.Empty);
             }
        }

        public string Serialize()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in this.InStock)
            {
                builder.AppendFormat("{0}|{1}", item.Key.Name, item.Value);
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        public Refrigerator Deserialize(string serializedData)
        {
            if (serializedData == null)
            {
                return MyFridge;
            }
            var serializedRefrigerator = serializedData.Split(new string[] {"|", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            
            for (var i = 0; i < serializedRefrigerator.Length; i += 2)
            {
                Refrigerator.MyFridge.Add(ProductFlyweightFactory.Factory.MakeProduct(serializedRefrigerator[i], serializedRefrigerator), int.Parse(serializedRefrigerator[i + 1]));
            }
            return MyFridge;
        }

        public IEnumerator<KeyValuePair<Product, int>> GetEnumerator()
        {
            return this.InStock.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.InStock.GetEnumerator();
        }


        public bool ContainsKey(Product key)
        {

            return this.InStock.ContainsKey(key);
        }

        public ICollection<Product> Keys
        {
            get { return this.InStock.Keys; }
        }

        bool IDictionary<Product, int>.Remove(Product key)
        {
            if (this.InStock.Remove(key))
            {
                OnChanged(EventArgs.Empty);
                return true;
            }
            else
            {
                return this.InStock.Remove(key);
            }
        }

        public bool TryGetValue(Product key, out int value)
        {
            return this.InStock.TryGetValue(key, out value);
        }

        public ICollection<int> Values
        {
            get { return this.InStock.Values; }
        }

        public void Add(KeyValuePair<Product, int> item)
        {
            this.InStock.Add(item.Key, item.Value);
            OnChanged(EventArgs.Empty);
        }

        public bool Contains(KeyValuePair<Product, int> item)
        {
            return this.InStock.Contains(item);
        }

        public void CopyTo(KeyValuePair<Product, int>[] array, int arrayIndex)
        {
        }

        public int Count
        {
            get { return this.InStock.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<Product, int> item)
        {
            if (this.InStock.Remove(item.Key))
            {
                OnChanged(EventArgs.Empty);
            }
            return this.InStock.Remove(item.Key);
            
        }
    }
}

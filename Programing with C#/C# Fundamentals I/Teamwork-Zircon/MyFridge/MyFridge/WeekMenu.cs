using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public delegate void ChangedWeekMenuEventHandler(object sender, EventArgs e);

    public class WeekMenu : ICalculable, IVegetarian, IFoodType, IEnumerable<KeyValuePair<Meal, int>>, IDictionary<Meal, int>
    {
        public event ChangedWeekMenuEventHandler Changed;

        private Dictionary<Meal, int> AllMeals { get; set; }

        public static WeekMenu MyMenu;

        static WeekMenu()
        {
            MyMenu = new WeekMenu();
        }

        private WeekMenu()
        {
            this.AllMeals = new Dictionary<Meal, int>();
        }

        private void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
        
        public decimal GetTotalValue()
        {
            return this.AllMeals.Sum(m => m.Key.GetTotalValue() * m.Value);
        }

        public bool IsVegetarian
        {
            get
            {
                return !this.AllMeals.Any(i => !(i.Key.IsVegetarian));
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (var meal in this.AllMeals)
            {
                output.Append(meal.Key.ToString());
            }
            return output.ToString();
        }

        public IEnumerator<KeyValuePair<Meal, int>> GetEnumerator()
        {
            return WeekMenu.MyMenu.AllMeals.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return WeekMenu.MyMenu.AllMeals.GetEnumerator();
        }

        public void Add(Meal key, int value)
        {
            if (this.AllMeals.ContainsKey(key))
            {
                this.AllMeals[key] += value;
            }
            else
            {
                this.AllMeals.Add(key, value);
            }
            OnChanged(EventArgs.Empty);
        }

        public bool ContainsKey(Meal key)
        {
            return this.AllMeals.ContainsKey(key);
        }

        public ICollection<Meal> Keys
        {
            get { return this.AllMeals.Keys; }
        }

        public bool Remove(Meal key)
        {
            if (this.AllMeals.ContainsKey(key))
            {
                OnChanged(EventArgs.Empty);
                return this.AllMeals.Remove(key);
            }
            else
            {
                throw new ArgumentException("Unable to remove the meal - no such meal in menu.");
            }
        }

        public bool TryGetValue(Meal key, out int value)
        {
            return this.AllMeals.TryGetValue(key, out value);
        }

        public ICollection<int> Values
        {
            get { return this.AllMeals.Values; }
        }

        public int this[Meal index]
        {
            get
            {
                if(this.AllMeals.ContainsKey(index))
                {
                    return this.AllMeals[index];
                }
                else
                {
                    throw new ArgumentException("No such meal in menu.");
                }
            }
            set 
             {
                this.AllMeals[index] = value;
                OnChanged(EventArgs.Empty);
             }
        }

        public void Add(KeyValuePair<Meal, int> item)
        {
            this.AllMeals.Add(item.Key, item.Value);
            OnChanged(EventArgs.Empty);
        }

        public void Clear()
        {
            this.AllMeals.Clear();
            OnChanged(EventArgs.Empty);
        }

        public bool Contains(KeyValuePair<Meal, int> item)
        {
            return this.AllMeals.Contains(item);
        }

        public void CopyTo(KeyValuePair<Meal, int>[] array, int arrayIndex)
        {
        }

        public int Count
        {
            get { return this.AllMeals.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<Meal, int> item)
        {
            if (this.AllMeals.Remove(item.Key))
            {
                OnChanged(EventArgs.Empty);
            }
            return this.AllMeals.Remove(item.Key);
        }

        public Dictionary<FoodType, int> GetFoodTypeDistribution()
        {
            var result = new Dictionary<FoodType, int>();
            foreach (var meal in this)
            {
                var currentFoodTypeDistribution = meal.Key.GetFoodTypeDistribution();
                foreach (var item in currentFoodTypeDistribution)
	            {
		            if(result.ContainsKey(item.Key))
                    {
                        result[item.Key] += item.Value;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
	            }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class MealFlyweightFactory
    {
        private IDictionary<string, Meal> availableMeals;

        public static MealFlyweightFactory Factory { get; private set; }

        static MealFlyweightFactory()
        {
            Factory = new MealFlyweightFactory();
        }

        private MealFlyweightFactory()
        {
            availableMeals = new Dictionary<string, Meal>();
        }

        public Meal CreateMeal(string name, string[] mealData)
        {
            Meal requestedMeal;
            if (!availableMeals.ContainsKey(name))
            {
                requestedMeal = new Meal(name, (MealType)int.Parse(mealData[1]));
                //add ingredients;
                for (int i = 2; i < mealData.Length; i += 2)
	            {
                    requestedMeal.Add(ProductFlyweightFactory.Factory.MakeProduct(mealData[i], mealData), int.Parse(mealData[i + 1]));
	            }
                availableMeals.Add(name, requestedMeal);
            }
            else
            {
                requestedMeal = availableMeals[name];
            }

            return requestedMeal;
        }

        public IEnumerable<Meal> GetAvailableMeals()
        {
            return availableMeals.Values;
        }
    }
}

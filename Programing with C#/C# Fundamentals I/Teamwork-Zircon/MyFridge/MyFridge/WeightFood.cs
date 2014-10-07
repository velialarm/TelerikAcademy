using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public abstract class WeightFood : Product
    {
        protected WeightFood(string name, BaseUnit measure, bool isVegetarian, FoodType type, decimal price) :
            base(name, measure, isVegetarian, type, new ShoppingUnit(ShoppingPackage.kg, 1000), price)
        {
        }
    }
}

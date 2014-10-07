using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public abstract class PackagedFood : Product
    {
        protected PackagedFood(string name, BaseUnit measure, bool isVegetarian, FoodType type, ShoppingUnit unit, decimal price) :
            base(name, measure, isVegetarian, type, unit, price)
        {
        }
    }
}

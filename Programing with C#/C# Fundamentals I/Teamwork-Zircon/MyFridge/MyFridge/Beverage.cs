using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class Beverage : PackagedFood
    {
        public Beverage(string name, double litresPerBottle, decimal price)
            : base(name, BaseUnit.grams, true, FoodType.Other, new ShoppingUnit(ShoppingPackage.bottle, (int)(1000 * litresPerBottle)), price)
        {
        }
    }
}

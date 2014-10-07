using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class LiquidFat : PackagedFood
    {
        public LiquidFat(string name, double litresPerBottle, decimal price)
            : base(name, BaseUnit.grams, true, FoodType.Other, new ShoppingUnit(ShoppingPackage.bottle, (int)(930 * litresPerBottle)), price)
        {
        }
    }
}

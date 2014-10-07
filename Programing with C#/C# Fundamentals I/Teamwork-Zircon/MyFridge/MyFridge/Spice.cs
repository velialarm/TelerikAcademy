using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class Spice : PackagedFood
    {
        public Spice(string name, int garmsPerShoppingPack, decimal price)
            : base(name, BaseUnit.grams, true, FoodType.Other, new ShoppingUnit(ShoppingPackage.packet, garmsPerShoppingPack), price)
        {
        }
    }
}

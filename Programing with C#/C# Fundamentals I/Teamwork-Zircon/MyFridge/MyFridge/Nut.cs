using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class Nut : PackagedFood
    {
        public Nut(string name, decimal price)
            : base(name, BaseUnit.grams, true, FoodType.Protein, new ShoppingUnit(ShoppingPackage.packet, 100), price)
        {
        }
    }
}

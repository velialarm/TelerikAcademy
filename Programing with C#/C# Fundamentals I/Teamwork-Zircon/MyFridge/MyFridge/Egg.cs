using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class Egg : PackagedFood
    {
        public Egg(decimal price)
            : base("Egg", BaseUnit.grams, false, FoodType.Protein, new ShoppingUnit(ShoppingPackage.package, 68 * 6), price)
        {
        }
    }
}

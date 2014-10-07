using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class Cereal : PackagedFood
    {
        public Cereal(string name, int gramsPerShoppingPack, decimal price)
            : base(name, BaseUnit.grams, true, FoodType.Grain, new ShoppingUnit(ShoppingPackage.packet, gramsPerShoppingPack), price)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class Legume : PackagedFood
    {
        public Legume(string name, int garmsPerShoppingPack, decimal price)
            : base(name, BaseUnit.grams, true, FoodType.Protein, new ShoppingUnit(ShoppingPackage.packet, garmsPerShoppingPack), price)
        {
        }
    }
}

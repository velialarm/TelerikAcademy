using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class Dairy : PackagedFood
    {
        public Dairy(string name, ShoppingUnit unit, decimal price)
            : base(name, BaseUnit.grams, false, FoodType.Dairy, unit, price)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class FruitVegetable : WeightFood
    {
        public FruitVegetable(string name, decimal price)
            : base(name, BaseUnit.grams, true, FoodType.FruitsVegetables, price)
        {
        }
    }
}

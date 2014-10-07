using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public class MeatFish : WeightFood
    {
        public MeatFish(string name, decimal price)
            : base(name, BaseUnit.grams, false, FoodType.Protein, price)
        {
        }
    }
}

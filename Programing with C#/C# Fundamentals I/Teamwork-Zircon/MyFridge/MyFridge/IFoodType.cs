using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public interface IFoodType
    {
        Dictionary<FoodType, int> GetFoodTypeDistribution();
    }
}

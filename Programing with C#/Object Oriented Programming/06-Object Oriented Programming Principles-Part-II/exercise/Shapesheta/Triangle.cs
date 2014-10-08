using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapesheta
{
    public class Triangle : Shape
    {
        public Triangle(int width, int height)
            :base(width,height)
        {
           
        }
    
        public override decimal CalculateSurface()
        {
            decimal result = (decimal)((Height * Width) / 2);
            return result;
        }
    }
}

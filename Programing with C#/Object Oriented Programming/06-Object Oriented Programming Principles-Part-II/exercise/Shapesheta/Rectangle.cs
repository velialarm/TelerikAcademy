using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapesheta
{
    public class Rectangle :Shape
    {
        public Rectangle(int width, int height)
            :base(width,height)
        {
           
        }
    
        public override decimal CalculateSurface()
        {
            decimal result = (decimal)(Height * Width);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapesheta
{
    public class Circle : Shape
    {
        public Circle(int width)
            : base(width, width)
        {
            this.Height = width;
        }

        public override decimal CalculateSurface()
        {
            decimal result = (decimal)(Math.PI * Math.Pow((Width/2),2));
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapesheta
{
    public abstract class Shape
    {
        private int width;
        private int height;

        public Shape(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public abstract decimal CalculateSurface();
    }
}

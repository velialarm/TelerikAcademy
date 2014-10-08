using System;

namespace Abstraction
{
    class Rectangle : Figure
    {

        private double width;
        private double height;

        public Rectangle()
            : base(0, 0)
        {
        }

        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double Height {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be positive!");
                }

                this.width = value;
            }
        }

        public override double Width {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be positive!");
                }

                this.height = value;
            }
        }

        public override double Radius
        {
            get
            {
                throw new NotImplementedException("Rectangle does not have Radius");
            }
            set
            {
                throw new NotImplementedException("Rectangle does not have Radius");
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}

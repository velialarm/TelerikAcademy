using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius;
        public override double Radius {
            get { return this.radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius must be positive!");
                }

                this.radius = value;
            }
        }

        public Circle()
        {
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double Width
        {
            get
            {
                throw new NotImplementedException("Circle does not have Width");
            }
            set
            {
                throw new NotImplementedException("Circle does not have Width");
            }
        }

        public override double Height
        {
            get
            {
                throw new NotImplementedException("Circle does not have Height");
            }
            set
            {
                throw new NotImplementedException("Circle does not have Height");
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}

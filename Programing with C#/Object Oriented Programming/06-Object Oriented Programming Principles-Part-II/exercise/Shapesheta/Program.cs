using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapesheta
{
    class Program
    {
        static void Main(string[] args)
        {
            // test behavior
            int height = 12;
            int width = 3;
            Circle circle = new Circle(height);
            Rectangle rectangle = new Rectangle(height, width);
            Triangle triangle = new Triangle(height, width);
            Console.WriteLine("Circle surface is: {0}",circle.CalculateSurface());
            Console.WriteLine("rectangle surface is: {0}", rectangle.CalculateSurface());
            Console.WriteLine("triangle surface is: {0}", triangle.CalculateSurface());
        }
    }
}


//Write methods that calculate the surface of a triangle
using System;
    class Triangle
    {
        static void Main()
        {
            //Side and an altitude to it; 
            //Three sides; 
            //Two sides and an angle between them.

            Console.WriteLine("Calculating the surface of a triangle: ");
            Console.WriteLine("1. By side and altitude ");
            Console.WriteLine("2. By 3 sides");
            Console.WriteLine("3. By 2 sides and an angle between them");
            Console.WriteLine("Choose from 1 to 3 else exit.");
            int choise = int.Parse(Console.ReadLine());
            double side1,side2, side3, altitude, surface;
            int angle;
  
            switch (choise)
            {
                case 1:
                    Console.Write("Enter side: ");
                    side1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter altitude: ");
                    altitude = double.Parse(Console.ReadLine());
                    surface = Surface(side1, altitude);
                    Console.WriteLine("The surface is: {0}", surface);
                    break;
                case 2:
                    Console.Write("Enter side: ");
                    side1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter side: ");
                    side2 = double.Parse(Console.ReadLine());
                    Console.Write("Enter side: ");
                    side3 = double.Parse(Console.ReadLine());
                    surface = Surface(side1, side2, side3);
                    Console.WriteLine("The surface is: {0}", surface);
                    break;
                case 3:
                    Console.Write("Enter side: ");
                    side1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter side: ");
                    side2 = double.Parse(Console.ReadLine());
                    Console.Write("Enter angle: ");
                    angle = int.Parse(Console.ReadLine());
                    surface = Surface(side1, side2, angle);
                    Console.WriteLine("The surface is: {0}", surface);
                    break;
                default:
                    return;
            }
            
        }
        public static double Surface(double a, double h)
        {
            return ((a * h) / 2);
        }
        public static double Surface(double a, double b, double c)
        { 
            double p = ((a + b + c) / 2);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public static double Surface(double a, double b, int angle)
        {
            double pi = Math.PI;
            double sin = Math.Sin((angle * pi) / 180);
            return ((a * b * sin) / 2);
        }
    }

